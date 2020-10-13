using System;
using System.IO;
using Microsoft.Diagnostics.Tracing.Session;
using Microsoft.Diagnostics.Tracing.Parsers;
using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.Parsers.Clr;
using System.Threading;
using Microsoft.Diagnostics.Tracing.Etlx;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using Microsoft.Diagnostics.Symbols;
using System.Collections.Generic;

using NtKeywords = Microsoft.Diagnostics.Tracing.Parsers.KernelTraceEventParser.Keywords;
using ClrKeywords = Microsoft.Diagnostics.Tracing.Parsers.ClrTraceEventParser.Keywords;

namespace sampler
{
    class CallStackNode : Dictionary<string, CallStackNode>
    {
        public CallStackNode(int callsCount) : base(StringComparer.OrdinalIgnoreCase)
        {
            CallsCount = callsCount;
        }

        public int CallsCount { get; set; }
    }

    class Program
    {
        private const string sessionName = "mytrace";
        private static readonly string etlFilePath = $"{sessionName}.etl";
        private static TextWriter log = Environment.GetEnvironmentVariable("ENABLE_TRACEEVENT_LOG") == null ? TextWriter.Null : Console.Out;

        static void Main(string[] args)
        {
            if (args.Length == 1 && args[0] == "trace")
            {
                if (TraceEventSession.IsElevated() == true)
                {
                    StartTrace();
                }
                else
                {
                    Console.WriteLine("ERROR: You must be admin to trace the system.");
                }
            }
            else if (args.Length >= 2 && args[0] == "analyze")
            {
                Analyze(args[1], args.Length > 2 ? Int32.Parse(args[2]) : 0);
            }
            else
            {
                Console.WriteLine("Usage: sampler trace | analyze <pid|process-name> [max-depth]");
            }
        }

        private static void StartTrace()
        {
            void CollectRundownEvents()
            {
                Console.WriteLine("Forcing rundown of JIT methods.");

                var rundownFilePath = Path.ChangeExtension(etlFilePath, "clrRundown.etl");
                using var rundownSession = new TraceEventSession(sessionName + "-rundown", rundownFilePath);
                rundownSession.EnableProvider(ClrRundownTraceEventParser.ProviderGuid, TraceEventLevel.Verbose,
                    (ulong)ClrRundownTraceEventParser.Keywords.Default);

                long length = -1;
                while (true)
                {
                    var newLength = new FileInfo(rundownFilePath).Length;
                    if (newLength == length)
                    {
                        return;
                    }
                    Thread.Sleep(2000);
                    length = newLength;
                }
            }

            using (var session = new TraceEventSession(sessionName, etlFilePath))
            {
                // kernel profiling events
                var traceFlags = NtKeywords.Profile | NtKeywords.ImageLoad;
                var stackFlags = NtKeywords.Profile;
                session.EnableKernelProvider(traceFlags, stackFlags);

                // JIT events required for stack resolution
                session.EnableProvider(ClrTraceEventParser.ProviderGuid, TraceEventLevel.Verbose, (ulong)ClrKeywords.JITSymbols);

                Console.Write("Press enter to stop the tracing session");
                Console.ReadLine();

                session.Stop();

                CollectRundownEvents();
                Console.WriteLine("Done with rundown");
            }

            Console.WriteLine("Collecting data required for stack resolution...");
            var writer = new ZippedETLWriter(etlFilePath, log);
            if (!writer.WriteArchive(System.IO.Compression.CompressionLevel.NoCompression))
            {
                Console.WriteLine("Error occured while merging");
            }
            else
            {
                Console.WriteLine("Trace session completed");
            }
        }
        private static bool TryFindProcess(TraceLog traceLog, string processNameOrPid, [NotNullWhen(true)] out TraceProcess? process)
        {
            var filter = Int32.TryParse(processNameOrPid, out var pid) ?
                (Func<TraceProcess, bool>)((TraceProcess p) => p.ProcessID == pid) :
                    ((TraceProcess p) => String.Equals(p.Name, processNameOrPid, StringComparison.OrdinalIgnoreCase));

            var processes = traceLog.Processes.Where(filter).ToArray();
            if (processes.Length == 0)
            {
                process = null;
                return false;
            }
            if (processes.Length == 1)
            {
                process = processes[0];
                return true;
            }
            for (int i = 0; i < processes.Length; i++)
            {
                var p = processes[i];
                Console.WriteLine($"[{i}] {p.Name} ({p.ProcessID}): '{p.CommandLine}'");
            }
            Console.Write("Which process to analyze []: ");
            if (Int32.TryParse(Console.ReadLine(), out var ind) && 0 < ind && ind < processes.Length)
            {
                process = processes[ind];
                return true;
            }
            process = null;
            return false;
        }

        private static void LoadSymbols(TraceLog traceLog, TraceProcess proc)
        {
            using var symbolReader = new SymbolReader(log);
            foreach (var m in proc.LoadedModules.Where(m => m.ModuleFile != null))
            {
                traceLog.CodeAddresses.LookupSymbolsForModule(symbolReader, m.ModuleFile);
            }
        }
        private static CallStackNode AddOrUpdateChildNode(CallStackNode node, TraceCallStack callStack)
        {
            var decodeAddress = $"{callStack.CodeAddress.ModuleName}!{callStack.CodeAddress.FullMethodName}";
            if (node.TryGetValue(decodeAddress, out var childNode))
            {
                childNode.CallsCount += 1;
            }
            else
            {
                childNode = new CallStackNode(1);
                node.Add(decodeAddress, childNode);
            }
            return childNode;
        }

        private static CallStackNode ProcessStackFrame(CallStackNode node, TraceCallStack callStack)
        {
            var caller = callStack.Caller;
            if (caller == null)
            {
                // root node
                node.CallsCount = node.CallsCount + 1;
            }
            var childNode = caller == null ? AddOrUpdateChildNode(node, callStack) : ProcessStackFrame(node, caller);
            return AddOrUpdateChildNode(childNode, callStack);
        }

        private static CallStackNode BuildCallStackTree(TraceLog traceLog, int pid, int tid)
        {
            var perfInfoTaskGuid = new Guid(0xce1dbfb4, 0x137e, 0x4da6, 0x87, 0xb0, 0x3f, 0x59, 0xaa, 0x10, 0x2c, 0xbc);
            var perfInfoOpcode = 46;

            var callStacks = new CallStackNode(0);
            foreach (var ev in traceLog.Events.Where(ev => ev.ProcessID == pid && ev.ThreadID == tid
                            && ev.TaskGuid == perfInfoTaskGuid && (int)ev.Opcode == perfInfoOpcode))
            {
                ProcessStackFrame(callStacks, ev.CallStack());
            }

            return callStacks;
        }

        private static void PrintCallStacks(string threadDesc, int maxDepth, CallStackNode node)
        {
            void PrintCallStacksRecursive(string name, int depth, CallStackNode node)
            {
                var indentation = String.Concat(Enumerable.Repeat("| ", depth));
                Console.WriteLine($"{indentation}├─ {name} [{node.CallsCount}]");
                if (node.Count == 0 || (maxDepth > 0 && depth >= maxDepth)) {
                    return;
                }
                foreach (var kv in node) {
                    PrintCallStacksRecursive(kv.Key, depth + 1, kv.Value);
                }
            }
            PrintCallStacksRecursive(threadDesc, 0, node);
        }

        private static void Analyze(string processNameOrPid, int maxDepth)
        {
            var reader = new ZippedETLReader(etlFilePath + ".zip", log);
            reader.UnpackArchive();

            var options = new TraceLogOptions() { ConversionLog = log };
            var traceLog = TraceLog.OpenOrConvert(etlFilePath, options);

            if (!TryFindProcess(traceLog, processNameOrPid, out var proc))
            {
                Console.WriteLine("No matching process found in the trace");
                return;
            }

            Console.WriteLine($"Analyzing {proc.Name} ({proc.ProcessID}): '{proc.CommandLine}'");

            var sw = Stopwatch.StartNew();
            Console.WriteLine($"[{sw.ElapsedMilliseconds} ms] Loading symbols for process modules");
            LoadSymbols(traceLog, proc);

            // usually, system process has PID 4, but TraceEvent attaches the drivers to the Idle process (0)
            var systemProc = traceLog.Processes.First(p => p.ProcessID == 0);
            Console.WriteLine($"[{sw.ElapsedMilliseconds} ms] Loading symbols for system modules");
            LoadSymbols(traceLog, systemProc);

            Console.WriteLine($"[{sw.ElapsedMilliseconds} ms] Starting call stack analysis");

            foreach (var thr in proc.Threads)
            {
                var pid = thr.Process.ProcessID;
                var callStacks = BuildCallStackTree(traceLog, pid, thr.ThreadID);

                PrintCallStacks($"Thread ({thr.ThreadID}) '{thr.ThreadInfo}'", maxDepth, callStacks);
            }
            Console.WriteLine($"[{sw.ElapsedMilliseconds} ms] Completed call stack analysis");
        }
    }
}
