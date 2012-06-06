using System;
using System.Diagnostics;

public static class TestTrace 
{
    private static readonly TraceSource logger = new TraceSource("TestTrace");

    public static void Main(String[] args) {
        logger.TraceInformation("Start");
        
        Console.WriteLine("In the middle of tracing");
        
        logger.TraceInformation("End");
    }
}