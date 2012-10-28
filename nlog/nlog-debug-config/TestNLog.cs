using System;
using System.Diagnostics;
using NLog;

public static class TestNLog
{
    private static readonly Logger logger = LogManager.GetLogger("TestLogger");
    private static TraceSource source = new TraceSource("TestSource");

    public static void Main(String[] args) {
        Guid prevActivityId = Trace.CorrelationManager.ActivityId;
        Guid newActivityId = Guid.NewGuid();
        source.TraceTransfer(0, "transfer", newActivityId);
        Trace.CorrelationManager.ActivityId = newActivityId;
        
        Console.WriteLine("Trace source logging");
        source.TraceInformation("kkkllll");

        logger.Info("Start");

        Console.WriteLine("In the middle of tracing");
        
        logger.ErrorException("Error occured", new Exception("TestException"));

        logger.Info("End");

        source.TraceTransfer(0, "transfer2", prevActivityId);
        Trace.CorrelationManager.ActivityId = prevActivityId;
    }
}