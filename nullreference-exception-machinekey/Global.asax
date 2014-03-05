<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Web.Configuration" %>

<script Language="c#" runat="server">

    void Application_Start(Object sender, EventArgs ev) {
        //UNCOMMENT to make it work: typeof (MachineKeySection).GetMethod("EnsureConfig", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).Invoke(null, null);
    }

    void Application_BeginRequest(Object sender, EventArgs ev)
    {
        try {
            var cookie = Request.Cookies["_sec"];
            if (cookie != null && !String.IsNullOrEmpty(cookie.Value)) {
                var txt = MachineKey.Decode(cookie.Value, MachineKeyProtection.Validation);
                if (txt == null) {
                    Response.Write("Cookie tampered.");
                } else {
                    Response.Write(Encoding.ASCII.GetString(txt));
                }
            }
        } catch (Exception ex) {
            Response.Write("Exception: " + ex);
        }
    }

    void Application_EndRequest(Object sender, EventArgs ev)
    {
        var signedtxt = MachineKey.Encode(Encoding.ASCII.GetBytes("test string"), MachineKeyProtection.Validation);
        Response.SetCookie(new HttpCookie("_sec", signedtxt));
    }

</script>
