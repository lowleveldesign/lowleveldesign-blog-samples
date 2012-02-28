using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Samples.Debugging.MdbgEngine;
using Microsoft.Samples.Tools.Mdbg;

namespace Mdb.Extension
{
    [MDbgExtensionEntryPointClass(Url = "http://lowleveldesign.wordpress.com")]
    public sealed class WatchTraceExtension : CommandBase
    {
        /// <summary>
        /// Loads extension into the debugger.
        /// </summary>
        public static void LoadExtension()
        {
            MDbgAttributeDefinedCommand.AddCommandsFromType(Shell.Commands, typeof(WatchTraceExtension));
            WriteOutput("wtrace extension loaded");
        }

        /* *** Extension options ** */

        private const String depthOption = "l";
        private const String incNamespacesOption = "inc";
        private const String excNamespacesOption = "exc";
        private const String continueOption = "continue";

        /* *** Extension variables *** */

        private static int threadId;
        private static int maxDepth;
        private static Regex incRgx;
        private static Regex excRgx;
        private static String startFuncName;
        private static String lastFuncName;
        private static int depth = -1;

        /* *** Extension helpers *** */

        // creates a regex for matching traced function names
        private static Regex GetNamespaceRegex(String namespaceOption)
        {
            String[] tokens = namespaceOption.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length > 0)
            {
                return new Regex("^(?:" + String.Join("|", tokens.Select(s => "(?:" + s + ")")) + ")",
                                    RegexOptions.Compiled | RegexOptions.Singleline);
            }
            return null;
        }

        // Parses arguments and prepares internal command variables
        private static void PrepareCall(String argString)
        {
            ArgParser parser = new ArgParser(argString, depthOption + ":1;" + incNamespacesOption + ":1;" +
                                                   excNamespacesOption + ":1;" + continueOption);
            if (parser.OptionPassed(continueOption))
            {
                if (depth < 0)
                {
                    throw new MDbgShellException("No last session found.");
                }
                WriteOutput("Continuing the last watch-trace session...");
            }
            else
            {
                // prepare a new watch-trace session
                threadId = Debugger.Processes.Active.Threads.Active.Id;

                startFuncName = Debugger.Processes.Active.Threads.Active.CurrentFrame.Function.FullName;
                lastFuncName = startFuncName;
                depth = 0;

                if (parser.OptionPassed(depthOption))
                {
                    maxDepth = parser.GetOption(depthOption).AsInt;
                    if (maxDepth < 0)
                        throw new MDbgShellException("Depth cannot be negative.");
                }
                if (parser.OptionPassed(incNamespacesOption))
                {
                    incRgx = GetNamespaceRegex(parser.GetOption(incNamespacesOption).AsString);
                }
                if (parser.OptionPassed(excNamespacesOption))
                {
                    excRgx = GetNamespaceRegex(parser.GetOption(excNamespacesOption).AsString);
                }
            }
        }

        private static MDbgFrame GetCurrentFrame()
        {
            // debuggee might be already dead
            if (!Debugger.Processes.HaveActive)
                return null;
            // valid are only step-complete stops
            Object stopReason = Debugger.Processes.Active.StopReason;
            Type stopReasonType = stopReason.GetType();
            if (stopReasonType != typeof(StepCompleteStopReason))
                return null;
            // must have active thread
            if (!Debugger.Processes.Active.Threads.HaveActive)
                return null;
            // if event came from a different thread we finish tracing
            var thread = Debugger.Processes.Active.Threads.Active;
            Debug.Assert(thread != null);
            if (thread.Id != threadId)
                return null;
            if (!thread.HaveCurrentFrame)
                return null;
            return thread.CurrentFrame;
        }

        private static int CalculateCallDepth(MDbgFrame frame)
        {
            int depth = 0;
            while (frame != null)
            {
                if (frame.IsManaged)
                {
                    Debug.Assert(frame.Function != null);
                    if (String.Equals(frame.Function.FullName, startFuncName, StringComparison.Ordinal))
                        return depth;
                }
                frame = frame.NextUp;
                depth++;
            }
            return -1;
        }

        private static void PrintCallStackTrace(String funcName, int depth)
        {
            if ((incRgx == null || incRgx.IsMatch(funcName)) && 
                (excRgx == null || !excRgx.IsMatch(funcName)))
            {
                String indentStr = new String(' ', depth);
                WriteOutput(String.Format("[{0,3}]  {1}{2}", depth, indentStr, funcName));
            }
        }

        /* *** Extension command *** */

        [CommandDescription(CommandName = "wtrace",
                            MinimumAbbrev = 2,
                            ShortHelp = "Watch trace command.",
                            LongHelp = @"Steps through the function calls, constructing a call tree.
Usage:
    wt [-l <depth>] [-inc <namespace>] [-exl <namespace>]
    wt -continue

-l <depth>                          the maximum depth of the calls to display
-inc <namespace1[,namespace2,...]>  include only calls from these namespaces (case sensitive, comma separated)
-exl <namespace[,namespace2,...]>   exclude calls from this namespace (case sensitive, comma separated)
-continue                           continues the last interrupted session (you need to switch to the session thred!)")]

        public static void WatchTrace(String argString)
        {
            PrepareCall(argString);

            while (true)
            {
                if (!Debugger.Processes.HaveActive)
                    break;
                // check call depth
                if (maxDepth > 0 && depth >= maxDepth)
                {
                    // if greater than maximum step out of the function
                    Debugger.Processes.Active.StepOut().WaitOne();
                }
                else
                {
                    // otherwise step one instruction
                    Debugger.Processes.Active.StepInto(false).WaitOne();
                }

                MDbgFrame frame = GetCurrentFrame();
                if (frame == null)
                    break;
                String funcName = frame.Function.FullName;
                if (!String.Equals(funcName, lastFuncName, StringComparison.Ordinal))
                {
                    depth = CalculateCallDepth(frame);
                    if (depth < 0)
                    {
                        // it may happen if we are out of our base function
                        // so we need to stop tracing
                        break;
                    }
                    PrintCallStackTrace(funcName, depth);
                    lastFuncName = funcName;
                }
            }
            // let's handle control to the debugger
            Shell.DisplayCurrentLocation();
        }
    }
}
