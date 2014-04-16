using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using NLog;
using NLog.LayoutRenderers;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace LowLevelDesign.NLog.Ext
{
    /// <summary>
    /// The trace correlation activity id.
    /// </summary>
    [LayoutRenderer("asmver")]
    [ThreadAgnostic]
    public class AssemblyVersionLayoutRenderer : LayoutRenderer
    {
        /// <summary>
        /// Specifies the assembly name for which the version will be displayed.
        /// By default the calling assembly is used.
        /// </summary>
        public String AssemblyName { get; set; }
        
        private String asmver;
        private String GetAssemblyVersion() {
            if (asmver != null) {
                return asmver;
            }
        
            InternalLogger.Debug("Assembly name '{0}' not yet loaded: ", AssemblyName);
            if (!String.IsNullOrEmpty(AssemblyName)) {
                // try to get assembly based on its name
                asmver = AppDomain.CurrentDomain.GetAssemblies()
                                      .Where(a => String.Equals(a.GetName().Name, AssemblyName, StringComparison.InvariantCultureIgnoreCase))
                                      .Select(a => a.GetName().Name + " v" + a.GetName().Version).FirstOrDefault();
                return asmver == null ? String.Format("<{0} not loaded>", AssemblyName) : asmver;
            }
            // get entry assembly
            var entry = Assembly.GetEntryAssembly();
            asmver = entry.GetName().Name + " v" + entry.GetName().Version;
            return asmver;
        }
    
        /// <summary>
        /// Renders the current trace activity ID.
        /// </summary>
        /// <param name="builder">The <see cref="StringBuilder"/> to append the rendered data to.</param>
        /// <param name="logEvent">Logging event.</param>
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(GetAssemblyVersion());
        }
    }
}