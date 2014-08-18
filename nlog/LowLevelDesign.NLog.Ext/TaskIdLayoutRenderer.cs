using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Text;
using NLog;
using NLog.LayoutRenderers;
using NLog.Config;
using NLog.Internal;

namespace LowLevelDesign.NLog.Ext
{
    /// <summary>
    /// The trace correlation activity id.
    /// </summary>
    [LayoutRenderer("taskid")]
    public class TaskIdLayoutRenderer : LayoutRenderer
    {
        /// <summary>
        /// Renders the current trace activity ID.
        /// </summary>
        /// <param name="builder">The <see cref="StringBuilder"/> to append the rendered data to.</param>
        /// <param name="logEvent">Logging event.</param>
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(Task.CurrentId);
        }
    }
}
