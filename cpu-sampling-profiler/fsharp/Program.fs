open System
open System.Collections.Generic
open System.IO
open System.Threading
open Microsoft.Diagnostics.Tracing
open Microsoft.Diagnostics.Tracing.Parsers
open Microsoft.Diagnostics.Tracing.Parsers.Clr
open Microsoft.Diagnostics.Tracing.Session
open Microsoft.Diagnostics.Tracing.Etlx
open Microsoft.Diagnostics.Symbols
open Microsoft.FSharp.Linq
open System.Diagnostics

type NtKeywords = KernelTraceEventParser.Keywords
type ClrKeywords = ClrTraceEventParser.Keywords

let sessionName = "mytrace"
let etlFilePath = sprintf "%s.etl" sessionName

let log = 
    if isNull (Environment.GetEnvironmentVariable("ENABLE_TRACEEVENT_LOG")) then TextWriter.Null
    else Console.Out

let startTrace () =
    let collectClrRundownEvents () = 
        let rec waitForRundownEvents filePath =
            // Poll until 2 second goes by without growth.
            let len = FileInfo(filePath).Length
            Thread.Sleep(2000)
            if FileInfo(filePath).Length <> len then
                waitForRundownEvents filePath
            else ()

        printfn "Forcing rundown of JIT methods."
        let rundownFileName = Path.ChangeExtension(etlFilePath, ".clrRundown.etl")
        use rundownSession = new TraceEventSession(sessionName + "-rundown", rundownFileName)
        rundownSession.EnableProvider(ClrRundownTraceEventParser.ProviderGuid, 
            TraceEventLevel.Verbose, uint64(ClrRundownTraceEventParser.Keywords.Default)) |> ignore
        waitForRundownEvents rundownFileName
        printfn "Done with rundown."

    do
        use session = new TraceEventSession(sessionName, etlFilePath)

        let traceFlags = NtKeywords.Profile ||| NtKeywords.ImageLoad // NtKeywords.Process and NtKeywords.Thread are added automatically
        let stackFlags = NtKeywords.Profile
        session.EnableKernelProvider(traceFlags, stackFlags) |> ignore
        
        // we need CLR to resolve managed stacks
        let keywords = ClrKeywords.JITSymbols
        session.EnableProvider(ClrTraceEventParser.ProviderGuid, TraceEventLevel.Always, uint64(keywords)) |> ignore
       
        printfn "Press enter to stop the tracing session"
        Console.ReadLine() |> ignore

        session.Stop() |> ignore

        collectClrRundownEvents ()

    printfn "Collecting the data required for stack resolution..."
    let writer = ZippedETLWriter(etlFilePath, log)
    if not (writer.WriteArchive(Compression.CompressionLevel.NoCompression)) then
        printfn "Error occured while merging the data"
    else
        printfn "Trace session completed"

type CallStackNode (callsCount : int32) =
    inherit Dictionary<string, CallStackNode>(StringComparer.OrdinalIgnoreCase)
    member val CallsCount = callsCount with get, set

let loadSymbols (traceLog : TraceLog) (proc : TraceProcess) =
    use symbolReader = new SymbolReader(log)

    proc.LoadedModules |> Seq.where (fun m -> not (isNull m.ModuleFile))
                       |> Seq.iter (fun m -> traceLog.CodeAddresses.LookupSymbolsForModule(symbolReader, m.ModuleFile))

let buildCallStacksTree (traceLog : TraceLog) pid tid =
    let perfInfoTaskGuid = Guid(int32 0xce1dbfb4, int16 0x137e, int16 0x4da6, byte 0x87, byte 0xb0, byte 0x3f, byte 0x59, byte 0xaa, byte 0x10, byte 0x2c, byte 0xbc)
    let perfInfoOpcode = 46

    let callStacks = CallStackNode(0)
    let processCallStack (callStack : TraceCallStack) =
        let addOrUpdateChildNode (node : CallStackNode) (callStack : TraceCallStack) =
            let decodedAddress = sprintf "%s!%s" callStack.CodeAddress.ModuleName callStack.CodeAddress.FullMethodName
            match node.TryGetValue(decodedAddress) with
            | (true, childNode) ->
                childNode.CallsCount <- childNode.CallsCount + 1
                childNode
            | (false, _) ->
                let childNode = CallStackNode(1)
                node.Add(decodedAddress, childNode)
                childNode

        let rec processStackFrame (callStackNode : CallStackNode) (callStack : TraceCallStack) =
            let caller = callStack.Caller
            if isNull caller then // root node
                callStackNode.CallsCount <- callStackNode.CallsCount + 1
            
            let childNode = 
                if isNull caller then addOrUpdateChildNode callStackNode callStack
                else processStackFrame callStackNode caller

            addOrUpdateChildNode childNode callStack
        processStackFrame callStacks callStack |> ignore
    
    traceLog.Events
    |> Seq.filter (fun ev -> ev.ProcessID = pid && ev.ThreadID = tid && ev.TaskGuid = perfInfoTaskGuid && (int32 ev.Opcode = perfInfoOpcode))
    |> Seq.iter (fun ev -> processCallStack (ev.CallStack()))

    callStacks

let tryFindProcess (traceLog : TraceLog) processNameOrPid =
    let (|Pid|ProcessName|) (s : string) =
        match Int32.TryParse(s) with
        | (true, pid) -> Pid pid
        | (false, _) -> ProcessName s

    let filter =
        match processNameOrPid with
        | Pid pid -> fun (p : TraceProcess) -> p.ProcessID = pid
        | ProcessName name -> fun (p : TraceProcess) -> String.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase)

    let processes = traceLog.Processes |> Seq.where filter |> Seq.toArray
    if processes.Length = 0 then
        None
    elif processes.Length = 1 then
        Some processes.[0]
    else
        processes |> Seq.iteri (fun i p -> printfn "[%d] %s (%d): '%s'" i p.Name p.ProcessID p.CommandLine)
        printf "Which process to analyze []: "
        match Int32.TryParse(Console.ReadLine()) with
        | (false, _) -> None
        | (true, n) -> processes |> Seq.tryItem n

let analyze processNameOrPid maxDepth =

    let reader = ZippedETLReader(etlFilePath + ".zip", log)
    reader.UnpackArchive()
    
    let options = TraceLogOptions(ConversionLog = log)
    let traceLog = TraceLog.OpenOrConvert(etlFilePath, options)

    match tryFindProcess traceLog processNameOrPid with
    | None -> printfn "No matching process found in the trace"
    | Some proc ->
        printfn "%s [%s] (%d)" proc.Name proc.CommandLine proc.ProcessID

        let sw = Stopwatch.StartNew()
        printfn "[%6d ms] Loading symbols for modules in process %s (%d)" sw.ElapsedMilliseconds proc.Name proc.ProcessID
        loadSymbols traceLog proc

        // usually, system process has PID 4, but TraceEvent attaches the drivers to the Idle process (0)
        let systemProc = traceLog.Processes |> Seq.where (fun p -> p.ProcessID = 0) |> Seq.exactlyOne

        printfn "[%6d ms] Loading symbols for system modules" sw.ElapsedMilliseconds
        loadSymbols traceLog systemProc

        printfn "[%6d ms] Starting call stack analysis" sw.ElapsedMilliseconds
        let printThreadCallStacks (thread : TraceThread) =
            let callStacks = buildCallStacksTree traceLog proc.ProcessID thread.ThreadID

            let rec getCallStack depth name (callStack : CallStackNode) =
                let folder frames (kv : KeyValuePair<string, CallStackNode>) =
                    if kv.Value.Count = 0 || (maxDepth > 0 && depth >= maxDepth) then frames
                    else getCallStack (depth + 1) kv.Key kv.Value |> List.append frames

                callStack
                |> Seq.fold folder [ (sprintf "%s├─ %s [%d]" ("│ " |> String.replicate depth) name callStack.CallsCount) ]

            let stacks = getCallStack 0 (sprintf "Thread (%d) '%s'" thread.ThreadID thread.ThreadInfo) callStacks
            stacks |> List.iter (fun s -> printfn "%s" s)
        
        proc.Threads |> Seq.iter printThreadCallStacks
        printfn "[%6d ms] Completed call stack analysis" sw.ElapsedMilliseconds

[<EntryPoint>]
let main argv =
    if argv.Length = 1 && argv.[0] = "trace" then
        if TraceEventSession.IsElevated() ?= true then
            startTrace ()
        else
            printfn "ERROR: You must be admin to trace the system."
    elif argv.Length >= 2 && argv.[0] = "analyze" then
        analyze argv.[1] (if argv.Length > 2 then Int32.Parse(argv.[2]) else 0)
    else
        printfn "Usage: etwprofiler trace | analyze <pid|process-name> [max-depth]"
    0
