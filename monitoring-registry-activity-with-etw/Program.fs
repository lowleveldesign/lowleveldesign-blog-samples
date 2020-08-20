open System
open System.Diagnostics
open System.Reflection
open System.Threading
open Microsoft.Diagnostics.Tracing.Parsers
open Microsoft.Diagnostics.Tracing.Session
open Microsoft.Diagnostics.Tracing.Parsers.Kernel
open Microsoft.Win32
open System.Collections.Generic
open System.IO

type NtKeywords = KernelTraceEventParser.Keywords
type ClrKeywords = ClrTraceEventParser.Keywords

let pid = Process.GetCurrentProcess().Id

let regHandleToKeyName = Dictionary<uint64, string>()

let processKCBCreateEvent (ev : RegistryTraceData) =
    printfn "%.4f %s [0x%X] <- '%s'" ev.TimeStampRelativeMSec ev.EventName ev.KeyHandle ev.KeyName 
    regHandleToKeyName.[ev.KeyHandle] <- ev.KeyName

let processKCBDeleteEvent (ev : RegistryTraceData) =
    printfn "%.4f %s [0x%X] <- '%s'" ev.TimeStampRelativeMSec ev.EventName ev.KeyHandle ev.KeyName 
    regHandleToKeyName.Remove(ev.KeyHandle) |> ignore

let filter (ev : RegistryTraceData) =
    ev.ProcessID = pid || ev.ProcessID = -1

let getFullKeyName keyHandle eventKeyName =
    let baseKeyName =
        match regHandleToKeyName.TryGetValue(keyHandle) with
        | (true, name) -> name
        | (false, _) -> ""
    Path.Combine(baseKeyName, eventKeyName)

let processKeyEvent (ev : RegistryTraceData) =
    if filter ev then
        let keyName = getFullKeyName ev.KeyHandle ev.KeyName
        printfn "%.4f (%d.%d) %s [0x%X] = '%s' [%d] -> %d (%.5f)" 
            ev.TimeStampRelativeMSec ev.ProcessID ev.ThreadID ev.EventName 
            ev.KeyHandle keyName ev.Index ev.Status ev.ElapsedTimeMSec

let processValueEvent (ev : RegistryTraceData) =
    if filter ev then
        let keyName = getFullKeyName ev.KeyHandle ev.ValueName
        printfn "%.4f (%d.%d) %s [0x%X] = '%s' [%d] -> %d (%.5f)" 
            ev.TimeStampRelativeMSec ev.ProcessID ev.ThreadID ev.EventName 
            ev.KeyHandle keyName ev.Index ev.Status ev.ElapsedTimeMSec

let makeKernelParserStateless traceSessionSource =
    let options = KernelTraceEventParser.ParserTrackingOptions.None
    let kernelParser = KernelTraceEventParser(traceSessionSource, options)

    let t = traceSessionSource.GetType()
    let kernelField = t.GetField("_Kernel", BindingFlags.Instance ||| BindingFlags.SetField ||| BindingFlags.NonPublic)
    kernelField.SetValue(traceSessionSource, kernelParser)

let runRundownSession sessionName =
    printf "Starting rundown session %s" sessionName
    use session = new TraceEventSession(sessionName)

    let traceFlags = NtKeywords.Registry
    
    session.EnableKernelProvider(traceFlags, NtKeywords.None) |> ignore

    // Accessing the source enables kernel provider so must be run after the EnableKernelProvider call
    makeKernelParserStateless session.Source
    session.Source.Kernel.add_RegistryKCBRundownBegin(Action<_>(processKCBCreateEvent))
    session.Source.Kernel.add_RegistryKCBRundownEnd(Action<_>(processKCBCreateEvent))

    // Rundown session lasts 2 secs - make it longer, if required
    use cts = new CancellationTokenSource(TimeSpan.FromSeconds(2.0))
    use _r = cts.Token.Register(fun _ -> session.Stop() |> ignore)

    session.Source.Process() |> ignore

let startSession (ct : CancellationToken) = 
    let sessionName = "mytrace"

    use session = new TraceEventSession(sessionName)

    let traceFlags = NtKeywords.Registry
    let stackFlags = NtKeywords.None
    session.EnableKernelProvider(traceFlags, stackFlags) |> ignore

    makeKernelParserStateless session.Source

    runRundownSession (sessionName + "-rundown")

    session.Source.Kernel.add_RegistryKCBCreate(Action<_>(processKCBCreateEvent))
    session.Source.Kernel.add_RegistryKCBDelete(Action<_>(processKCBDeleteEvent))
    // session.Source.Kernel.add_RegistryKCBRundownBegin(Action<_>(processKCBCreateEvent))
    // session.Source.Kernel.add_RegistryKCBRundownEnd(Action<_>(processKCBCreateEvent))
    let processKeyEventAction = Action<_>(processKeyEvent)
    let processValueEventAction = Action<_>(processValueEvent)
    
    session.Source.Kernel.add_RegistryCreate(processKeyEventAction)
    session.Source.Kernel.add_RegistryOpen(processKeyEventAction)
    session.Source.Kernel.add_RegistryClose(processKeyEventAction)
    session.Source.Kernel.add_RegistryFlush(processKeyEventAction)
    session.Source.Kernel.add_RegistryEnumerateKey(processKeyEventAction)
    session.Source.Kernel.add_RegistryQuery(processKeyEventAction)
    session.Source.Kernel.add_RegistrySetInformation(processKeyEventAction)
    session.Source.Kernel.add_RegistryVirtualize(processKeyEventAction)
    session.Source.Kernel.add_RegistryDelete(processKeyEventAction)
    
    session.Source.Kernel.add_RegistryEnumerateValueKey(processValueEventAction)
    session.Source.Kernel.add_RegistryQueryValue(processValueEventAction)
    session.Source.Kernel.add_RegistryQueryMultipleValue(processValueEventAction)
    session.Source.Kernel.add_RegistrySetValue(processValueEventAction)
    session.Source.Kernel.add_RegistryDeleteValue(processValueEventAction)

    use _r = ct.Register(fun () -> session.Stop() |> ignore)

    session.Source.Process() |> ignore

    printfn "Session stopped"

[<EntryPoint>]
let main _ =
    use cts = new CancellationTokenSource()

    async { startSession cts.Token } |> Async.Start

    Console.CancelKeyPress.Add(fun ev -> ev.Cancel <- true; cts.Cancel())

    // let's give the trace session some time to start
    Thread.Sleep(4000)

    let subkey = "Software\\LowLevelDesign"

    use hkcu = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default)
    do 
        use mytraceKey = hkcu.CreateSubKey(subkey)

        mytraceKey.SetValue("start", DateTime.UtcNow.ToString(), RegistryValueKind.String)

    Console.WriteLine("Press enter to delete the key...")
    Console.ReadLine() |> ignore

    hkcu.DeleteSubKeyTree(subkey)

    Thread.Sleep(1500)
    cts.Cancel()

    // wait a moment for output
    Async.Sleep(2000) |> Async.RunSynchronously
    0
