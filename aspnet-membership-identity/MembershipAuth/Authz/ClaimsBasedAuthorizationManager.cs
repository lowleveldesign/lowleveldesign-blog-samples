using Microsoft.IdentityModel.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MembershipAuth.Authz
{
    public class AuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            var action = context.Action.FirstOrDefault();
            if (action != null && String.Equals(action.Value, "LoginAsKing", StringComparison.Ordinal)) {
                foreach (ClaimsIdentity identity in context.Principal.Identities) {
                    if (identity.Claims.Where(c => String.Equals(c.ClaimType, "urn:usertype", StringComparison.Ordinal) 
                            && String.Equals(c.Value, "king", StringComparison.Ordinal)).Any()) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}