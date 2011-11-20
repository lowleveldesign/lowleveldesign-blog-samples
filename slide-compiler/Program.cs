using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using DiagnosticHelper;

namespace SlideCompiler
{
    class SlideCompiler
    {
        static void Main(string[] args)
        {
            var argParser = new SlideCompilerArgParser();
            if (!argParser.Parse(args))
            {
                return;
            }
            new SlideCompiler().Compile(argParser.TableOfContentsPath,
                                        argParser.SlidesMappingPath,
                                        argParser.OutputFileName);
        }

        public void Compile(String tableOfContentsPath, String slidesMappingPath, String outputFileName)
        {
            Debug.Assert(tableOfContentsPath != null);
            Debug.Assert(slidesMappingPath != null);

            // Create a dynamic assembly and module
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = Path.GetFileNameWithoutExtension(tableOfContentsPath);
            AssemblyBuilder assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);

            // Mark generated code as debuggable. 
            // See http://blogs.msdn.com/rmbyers/archive/2005/06/26/432922.aspx for explanation.        
            Type daType = typeof(DebuggableAttribute);
            ConstructorInfo daCtor = daType.GetConstructor(new Type[] { typeof(DebuggableAttribute.DebuggingModes) });
            CustomAttributeBuilder daBuilder = new CustomAttributeBuilder(daCtor, new object[] { 
                DebuggableAttribute.DebuggingModes.DisableOptimizations | 
                DebuggableAttribute.DebuggingModes.Default });
            assemblyBuilder.SetCustomAttribute(daBuilder);

            ModuleBuilder module = assemblyBuilder.DefineDynamicModule(outputFileName, true); // <-- pass 'true' to track debug info.

            // Tell Emit about the source file that we want to associate this with. 
            ISymbolDocumentWriter doc = module.DefineDocument(tableOfContentsPath, Guid.Empty, Guid.Empty, Guid.Empty);

            // create a new type to hold our Main method 
            TypeBuilder typeBuilder = module.DefineType("Program", TypeAttributes.Public | TypeAttributes.Class);

            // emit a method for showing a slide
            MethodInfo readAndPrintSlideMethod = emitReadAndPrintSlideMethod(typeBuilder);

            /* *** Load the mapping file and then parse slides *** */
            var slidesMapping = new Dictionary<String, String>();
            using (StreamReader reader = new StreamReader(new FileStream(slidesMappingPath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                String slideTitle = null;
                String line;
                do
                {
                    line = reader.ReadLine();
                    if (slideTitle == null)
                    {
                        // we just read slide title
                        slideTitle = line;
                    }
                    else
                    {
                        if (!String.IsNullOrWhiteSpace(line) && Char.IsWhiteSpace(line, 0))
                        {
                            // add a mapping between a slide title and its content file
                            slidesMapping.Add(slideTitle, line.Trim());
                            slideTitle = null;
                        }
                    }

                } while (line != null);
            }

            // create the Main(string[] args) method 
            MethodBuilder methodBuilder = typeBuilder.DefineMethod("Main", MethodAttributes.HideBySig | MethodAttributes.Static | MethodAttributes.Public, typeof(void), new Type[] { typeof(string[]) });

            // generate the IL for the Main method 
            ILGenerator ilGenerator = methodBuilder.GetILGenerator();

            // color the console
            ilGenerator.Emit(OpCodes.Ldc_I4_S, 15);
            ilGenerator.Emit(OpCodes.Call, typeof(Console).GetProperty("BackgroundColor").GetSetMethod());
            ilGenerator.Emit(OpCodes.Ldc_I4_0);
            ilGenerator.Emit(OpCodes.Call, typeof(Console).GetProperty("ForegroundColor").GetSetMethod());

            // parse the slides and emit calls to the readAndPringSlide
            using (StreamReader reader = new StreamReader(new FileStream(tableOfContentsPath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                bool breakEmitted = false;
                String line;
                int lineNum = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    if (slidesMapping.ContainsKey(line))
                    {
                        // if a given slide title has a mapping
                        ilGenerator.Emit(OpCodes.Ldstr, slidesMapping[line]);
                        ilGenerator.Emit(OpCodes.Call, readAndPrintSlideMethod);
                        // emit sequence point
                        ilGenerator.MarkSequencePoint(doc, lineNum, 1, lineNum, 100);
                        // only for the first instruction, notify the debugger
                        if (!breakEmitted)
                        {
                            // first emit call to notice the debugger
                            ilGenerator.Emit(OpCodes.Call, typeof(Debugger).GetMethod("Break"));
                            breakEmitted = true;
                        }
                    }
                    lineNum++;
                }
            }
            ilGenerator.Emit(OpCodes.Ret);

            // create a type
            Type programType = typeBuilder.CreateType();

            // set the entry point for the application and save it
            assemblyBuilder.SetEntryPoint(methodBuilder, PEFileKinds.ConsoleApplication);

            // Save the assembly to the disk
            assemblyBuilder.Save(outputFileName);
        }

        private MethodInfo emitReadAndPrintSlideMethod(TypeBuilder typeBuilder)
        {
            // public void readAndPrintSlide(String fileName)
            // {
            MethodBuilder methodBuilder = typeBuilder.DefineMethod("readAndPrintSlide", MethodAttributes.HideBySig | MethodAttributes.Static | MethodAttributes.Private, typeof(void), new Type[] { typeof(string) });

            ILGenerator ilGenerator = methodBuilder.GetILGenerator();

            ilGenerator.DeclareLocal(typeof(StreamReader)); // loc_0
            ilGenerator.DeclareLocal(typeof(bool)); // loc_1

            //     using (StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read)))
            //     {
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldc_I4_3);
            ilGenerator.Emit(OpCodes.Ldc_I4_1);
            ilGenerator.Emit(OpCodes.Ldc_I4_1);
            ilGenerator.Emit(OpCodes.Newobj, typeof(FileStream).GetConstructor(new Type[] {
                typeof(string),
                typeof(FileMode),
                typeof(FileAccess),
                typeof(FileShare)
            }));
            ilGenerator.Emit(OpCodes.Newobj, typeof(StreamReader).GetConstructor(new Type[] { typeof(Stream) }));
            ilGenerator.Emit(OpCodes.Stloc_0);

            ilGenerator.BeginExceptionBlock();

            // return lable
            Label ret = ilGenerator.DefineLabel();
            Label endfinally = ilGenerator.DefineLabel();

            //         Console.Clear();
            ilGenerator.Emit(OpCodes.Call, typeof(Console).GetMethod("Clear"));

            //         Console.Write(reader.ReadToEnd());
            ilGenerator.Emit(OpCodes.Ldloc_0);
            ilGenerator.Emit(OpCodes.Callvirt, typeof(TextReader).GetMethod("ReadToEnd"));

            ilGenerator.Emit(OpCodes.Call, typeof(Console).GetMethod("Write", new Type[] { typeof(String)}));

            ilGenerator.Emit(OpCodes.Leave_S, ret);

            //     }
            ilGenerator.BeginFinallyBlock();

            ilGenerator.Emit(OpCodes.Ldloc_0);
            ilGenerator.Emit(OpCodes.Ldnull);
            ilGenerator.Emit(OpCodes.Ceq);
            ilGenerator.Emit(OpCodes.Stloc_1); // cast to bool
            ilGenerator.Emit(OpCodes.Ldloc_1);
            ilGenerator.Emit(OpCodes.Brtrue_S, endfinally);

            ilGenerator.Emit(OpCodes.Ldloc_0);
            ilGenerator.Emit(OpCodes.Callvirt, typeof(IDisposable).GetMethod("Dispose"));

            ilGenerator.MarkLabel(endfinally);
            ilGenerator.Emit(OpCodes.Endfinally);

            ilGenerator.EndExceptionBlock();

            ilGenerator.MarkLabel(ret);
            ilGenerator.Emit(OpCodes.Ret);
            // }

            return methodBuilder;
        }
    }

    internal sealed class SlideCompilerArgParser : ArgParser
    {
        private String errorMessage;
        private String tableOfContentsPath;
        private String slidesMappingPath;
        private String outputFileName;

        internal SlideCompilerArgParser() : base(new String[] { "?" }, new String[] { "o", "files" }) { }

        protected override SwitchStatus OnNonSwitch(String value)
        {
            if (!String.IsNullOrEmpty(tableOfContentsPath))
            {
                errorMessage = "The code file name was already specified. The compiler can process only one file at a time.";
                return SwitchStatus.Error;
            }
            if (!File.Exists(value))
            {
                errorMessage = "The specified file does not exist.";
                return SwitchStatus.Error;
            }
            tableOfContentsPath = value;
            return SwitchStatus.NoError;
        }

        protected override SwitchStatus OnSwitch(String switchSymbol, String switchValue)
        {
            if (String.Equals(switchSymbol, "o", StringComparison.Ordinal))
            {
                outputFileName = switchValue;
            }
            else if (String.Equals(switchSymbol, "files", StringComparison.Ordinal))
            {
                slidesMappingPath = switchValue;
                if (!File.Exists(slidesMappingPath))
                {
                    errorMessage = "The map file does not exist.";
                    return SwitchStatus.Error;
                }
            }
            return SwitchStatus.NoError;
        }

        protected override SwitchStatus OnDoneParse()
        {
            if (String.IsNullOrEmpty(tableOfContentsPath))
            {
                errorMessage = "You need to specify the slides file.";
                return SwitchStatus.Error;
            }
            if (!File.Exists(tableOfContentsPath))
            {
                errorMessage = "The table of contents file does not exist.";
                return SwitchStatus.Error;
            }
            if (String.IsNullOrEmpty(outputFileName))
            {
                outputFileName = Path.GetDirectoryName(tableOfContentsPath);
                outputFileName += String.Format("{0}.exe", Path.GetFileNameWithoutExtension(tableOfContentsPath));
            }
            return SwitchStatus.NoError;
        }

        public override void OnUsage(String errorInfo)
        {
            // Logo
            Console.WriteLine("Slides compiler.");
            Console.WriteLine("Copyright (C) 2011 Sebastian Solnica");
            Console.WriteLine("For more information visit http://lowleveldesign.wordpress.com");
            Console.WriteLine();

            if (errorInfo != null)
            {
                Console.WriteLine("Invalid switch: {0}", errorInfo);
            }
            if (!String.IsNullOrEmpty(errorMessage))
            {
                Console.WriteLine("ERROR: {0}", errorMessage);
            }

            ProcessModule exe = Process.GetCurrentProcess().Modules[0];

            // print information about usage
            Console.WriteLine("Usage: {0} [options] <table_of_contents_file>", Path.GetFileName(exe.FileName));
            Console.WriteLine("Options:");
            Console.WriteLine("-o <output_file>          - specify the name of the generated file (default is code.exe)");
            Console.WriteLine("-files <slides_map_file>  - specify the name of the file containing a mapping between slides and their content files.");
            Console.WriteLine("-?                        - this help information");
        }

        public String TableOfContentsPath { get { return this.tableOfContentsPath; } }

        public String SlidesMappingPath { get { return this.slidesMappingPath; } }

        public String OutputFileName { get { return this.outputFileName; } }
    }
}
