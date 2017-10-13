<%@ WebHandler Language="C#" Class="EncryptionHandler" %>

using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;

public class EncryptionHandler : IHttpHandler
{
    static readonly byte[] secret = Convert.FromBase64String("QlNpZGVzV2Fyc2F3");

    public void ProcessRequest(HttpContext context)
    {
        var viewState = context.Request.Form["VIEWSTATE"];

        if (viewState == null) {
            viewState = MachineKey.Encode(secret, MachineKeyProtection.Encryption);
            context.Response.ContentType = "text/html";
            context.Response.Write("<!doctype html><html><form action=\"/EncryptionHandler.ashx\" method=\"POST\">" +
                "<input type=\"hidden\" name=\"VIEWSTATE\" value=\"" + viewState + "\" />" +
                "<input type=\"submit\" value=\"Test\" /></form></html>");
            return;
        }

        var v = MachineKey.Decode(viewState, MachineKeyProtection.Encryption);
        context.Response.ContentType = "text/plain";
        if (v.SequenceEqual(secret)) {
            context.Response.Write("I know the secret");
        } else {
            context.Response.Write("Something is wrong with my secret.");
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }
}
