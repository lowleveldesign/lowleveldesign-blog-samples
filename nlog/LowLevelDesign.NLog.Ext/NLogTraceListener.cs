using System;
using System.Diagnostics;
using System.Reflection;
using NLog;

namespace LowLevelDesign.NLog 
{
    public class NLogTraceListener : global::NLog.NLogTraceListener
    {
        private static readonly Assembly systemAssembly = typeof(Trace).Assembly;
    
        public override void TraceTransfer(TraceEventCache eventCache, string loggerName, int eventId, string message, Guid relatedActivityId)
        {
           var ev = new LogEventInfo();

            ev.LoggerName = (loggerName ?? this.Name) ?? string.Empty;
            
#if !NET_CF
            if (this.AutoLoggerName)
            {
                var stack = new StackTrace();
                int userFrameIndex = -1;
                MethodBase userMethod = null;

                for (int i = 0; i < stack.FrameCount; ++i)
                {
                    var frame = stack.GetFrame(i);
                    var method = frame.GetMethod();

                    if (method.DeclaringType == this.GetType())
                    {
                        // skip all methods of this type
                        continue;
                    }

                    if (method.DeclaringType.Assembly == systemAssembly)
                    {
                        // skip all methods from System.dll
                        continue;
                    }

                    userFrameIndex = i;
                    userMethod = method;
                    break;
                }

                if (userFrameIndex >= 0)
                {
                    ev.SetStackTrace(stack, userFrameIndex);
                    if (userMethod.DeclaringType != null)
                    {
                        ev.LoggerName = userMethod.DeclaringType.FullName;
                    }
                }
            }
#endif

            ev.TimeStamp = DateTime.Now;
            ev.Message = message;
            ev.Level = this.ForceLogLevel ?? LogLevel.Debug;

            ev.Properties.Add("EventID", eventId);
            ev.Properties.Add("RelatedActivityID", relatedActivityId);

            Logger logger = LogManager.GetLogger(ev.LoggerName);
            logger.Log(ev);
        }
    }
}
