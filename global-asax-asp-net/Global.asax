<%@ Application Language="C#" %>
<%@ Import Namespace="System.Diagnostics" %>

<script runat="server">

    public Guid AppId = Guid.NewGuid();

    public String TestMessage;

    public String GetAppDescription(String eventName)
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendFormat("-------------------------------------------{0}", Environment.NewLine);
        builder.AppendFormat("Event: {0}{1}", eventName, Environment.NewLine);
        builder.AppendFormat("Guid: {0}{1}", AppId, Environment.NewLine);
        builder.AppendFormat("Thread Id: {0}{1}", System.Threading.Thread.CurrentThread.ManagedThreadId, Environment.NewLine);
        builder.AppendFormat("Appdomain: {0}{1}", AppDomain.CurrentDomain.FriendlyName, Environment.NewLine);
        builder.AppendFormat("TestMessage: {0}{1}", TestMessage, Environment.NewLine);
        builder.Append((System.Threading.Thread.CurrentThread.IsThreadPoolThread ? "Pool Thread" : "No Thread") + Environment.NewLine);

        return builder.ToString();
    }
    
    void Application_Start(object sender, EventArgs e) 
    {
        TestMessage = "not null";
        
        // Code that runs on application startup
        Trace.WriteLine(GetAppDescription("Application_Start"));
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        Trace.WriteLine(GetAppDescription("Application_End"));
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        Trace.WriteLine(GetAppDescription("Application_Error"));
    }

    void Application_BeginRequest(object sender, EventArgs e)
    {
        Trace.WriteLine(GetAppDescription("Application_BeginRequest"));
    }

    void Application_EndRequest(object sender, EventArgs e)
    {
        Trace.WriteLine(GetAppDescription("Application_EndRequest"));
    }    
</script>
