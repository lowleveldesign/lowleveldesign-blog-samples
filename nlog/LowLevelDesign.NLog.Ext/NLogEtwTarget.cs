using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.NLog.Ext
{
    [Target("EventTracing")]
    public sealed class NLogEtwTarget : TargetWithLayout
    {
        private EventProvider provider;
        private Guid providerId = Guid.NewGuid();

        /// <summary>
        /// A provider guid that will be used in ETW tracing.
        /// </summary>
        public String ProviderId {
            get { return providerId.ToString(); }
            set {
                providerId = Guid.Parse(value);
            }
        }

        protected override void InitializeTarget() {
            base.InitializeTarget();

            // we will create a TraceListener
            provider = new EventProvider(providerId);
        }

        protected override void Write(LogEventInfo logEvent) {
            if (!provider.IsEnabled()) {
                return;
            }
            TraceEventType t = 0;
            if (logEvent.Level == LogLevel.Debug || logEvent.Level == LogLevel.Trace) {
                t = TraceEventType.Verbose;
            } else if (logEvent.Level == LogLevel.Info) {
                t = TraceEventType.Information;
            } else if (logEvent.Level == LogLevel.Warn) {
                t = TraceEventType.Warning;
            } else if (logEvent.Level == LogLevel.Error) {
                t = TraceEventType.Error;
            } else if (logEvent.Level == LogLevel.Fatal) {
                t = TraceEventType.Critical;
            }

            EventDescriptor evdesc = new EventDescriptor(logEvent.SequenceID, 0, 0, (byte)t, 0, 0, 0);
            provider.WriteEvent(ref evdesc, this.Layout.Render(logEvent));
        }

        protected override void CloseTarget() {
            base.CloseTarget();

            provider.Dispose();
        }
    }
}
