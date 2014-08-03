using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Authorization.Mvc;

namespace MembershipAuth.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index() {
            return Content(User.Identity.IsAuthenticated ? User.Identity.Name : "Anonymous");
        }

        [Authorize]
        public ActionResult Auth() {
            return Content("auth");
        }

        [ClaimsAuthorize("LoginAsKing")]
        public ActionResult ClaimsAuth()
        {
            return Content("authz");
        }
    }
}
