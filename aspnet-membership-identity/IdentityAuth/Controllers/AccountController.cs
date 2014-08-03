using IdentityAuth.Models;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IdentityAuth.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!String.Equals(model.Login, "test", StringComparison.Ordinal) && !String.Equals(model.Login, "admin", StringComparison.Ordinal) ||
                !String.Equals(model.Password, "1234", StringComparison.Ordinal)) {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            var identity = new GenericIdentity(model.Login, "ApplicationCookie");
            var claims = new Claim[0];
            if (model.Login.Equals("test", StringComparison.Ordinal))
            {
                claims = new[] { new Claim("urn:usertype", "king") };
            }
            var claimsIdentity = new ClaimsIdentity(identity, claims);

            AuthenticationManager.SignIn(new AuthenticationProperties() { }, claimsIdentity);
            SetFormsAuthCookie(claimsIdentity);

            return RedirectToAction("Index");
        }

        private void SetFormsAuthCookie(ClaimsIdentity identity) {
            // we need to serialize claims to string
            var userData = JsonConvert.SerializeObject(identity.Claims.Select(c => new SimpleClaim { ClaimType = c.Type, Value = c.Value }));
            // then create an auth ticket
            var cookie = FormsAuthentication.GetAuthCookie(identity.Name, false);
            var authTicket = FormsAuthentication.Decrypt(cookie.Value);
            authTicket = new FormsAuthenticationTicket(authTicket.Version, authTicket.Name,
                                                       authTicket.IssueDate, authTicket.Expiration,
                                                       authTicket.IsPersistent,
                                                       userData,
                                                       authTicket.CookiePath);
            cookie.Value = FormsAuthentication.Encrypt(authTicket);
            // and place it in authorization cookie
            Response.SetCookie(cookie);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        public class SimpleClaim
        {
            public String ClaimType { get; set; }

            public String Value { get; set; }
        }
    }
}