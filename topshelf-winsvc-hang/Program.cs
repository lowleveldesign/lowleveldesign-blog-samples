using System;
using System.Threading;
using Topshelf;
using Topshelf.Logging;

namespace LowLevelDesign.Samples
{
    class TestWorker : ServiceControl
    {
        private const int ThreadCount = 5;
        private static readonly LogWriter logger = HostLogger.Get<TestWorker>();
        public static bool ShouldStop { get; private set; }
        private WaitHandle[] handles;
        
        public bool Start(HostControl hostControl)
        {
            logger.Info("Starting test worker...");

            handles = new ManualResetEvent[ThreadCount];
            for (int i = 0; i < handles.Length; i++)
            {
                handles[i] = new ManualResetEvent(false);
            }
            logger.Info("Starting worker threads...");
            for (int i = 0; i < ThreadCount; i++)
            {
                // start the listenening thread
                ThreadPool.QueueUserWorkItem(Test, handles[i]);
            }
            return true;
        }
        
        private static void Test(Object state) 
        {
            var h = (ManualResetEvent)state;
            try 
            {
                throw new Exception();
            } 
            /* UNCOMMENT the missing part: 
            catch 
            {
                logger.InfoFormat("Releasing the handle on exception.");
                h.Set();
                throw;
            } */
            finally 
            {
                logger.InfoFormat("Releasing the handle");
                h.Set();
            }
        }

        public bool Stop(HostControl hostControl)
        {
            ShouldStop = true;
            logger.Info("Stopping test worker...");
            // wait for all threads to finish
            WaitHandle.WaitAll(handles);

            return true;
        }
    }

    class Program
    {
        static void Main()
        {
            HostFactory.Run(hc =>
            {
                hc.UseNLog();
                // service is constructed using its default constructor
                hc.Service<TestWorker>();
                // sets service properties
                hc.SetServiceName(typeof(TestWorker).Namespace);
                hc.SetDisplayName(typeof(TestWorker).Namespace);
                hc.SetDescription("Test worker");
            });
        }
    }
}
