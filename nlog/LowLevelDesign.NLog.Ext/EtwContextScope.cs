using Microsoft.Diagnostics.Tracing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LowLevelDesign.NLog.Ext
{
    public sealed class EtwContextScope : IDisposable
    {
        private bool disposed = false;
        private readonly Guid prevTraceActivityId;
        private readonly Guid prevEtwActivityId;

        public EtwContextScope()
            : this(Guid.NewGuid())
        {
        }

        public EtwContextScope(Guid activityId)
        {
            prevTraceActivityId = Trace.CorrelationManager.ActivityId;
            Trace.CorrelationManager.ActivityId = activityId;
            EventSource.SetCurrentThreadActivityId(activityId, out prevEtwActivityId);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                EventSource.SetCurrentThreadActivityId(prevEtwActivityId);
                Trace.CorrelationManager.ActivityId = prevTraceActivityId;
            }
        }
    }
}