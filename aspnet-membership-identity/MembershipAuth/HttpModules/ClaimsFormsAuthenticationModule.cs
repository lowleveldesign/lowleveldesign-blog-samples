using Microsoft.IdentityModel.Claims;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Security;

namespace MembershipAuth.HttpModules
{
    public class ClaimsFormsAuthenticationModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PostAuthenticateRequest += context_PostAuthenticateRequest;
        }

        void context_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var user = HttpContext.Current.User;
            if (user != null && user.Identity.IsAuthenticated && user.Identity is FormsIdentity)
            {
                var formsIdentity = (FormsIdentity)user.Identity;
                // user is authenticated - we will transform his identity
                var claimsPrincipal = new ClaimsPrincipal(user);
                var claimsIdentity = (ClaimsIdentity)claimsPrincipal.Identity;

                if (!String.IsNullOrEmpty(formsIdentity.Ticket.UserData))
                {
                    foreach (var sc in JsonConvert.DeserializeObject<IEnumerable<SimpleClaim>>(formsIdentity.Ticket.UserData))
                    {
                        var c = new Claim(sc.ClaimType, sc.Value);
                        if (!claimsIdentity.Claims.Contains(c))
                        {
                            claimsIdentity.Claims.Add(c);
                        }
                    }
                }

                HttpContext.Current.User = claimsPrincipal;
                Thread.CurrentPrincipal = claimsPrincipal;
            }
        }

        public class SimpleClaim
        {
            public String ClaimType { get; set; }

            public String Value { get; set; }
        }
    }
}