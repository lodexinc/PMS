using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using PMS.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace PMS.Security.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" } );
            //if (!context.OwinContext.Response.Headers.Contains(new KeyValuePair<string, string[]>("Access-Control-Allow-Origin", new[] { "*" })))
            //{
            //    context.OwinContext.Response.Headers.Remove("Access-Control-Allow-Origin");
            //    context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            //}

            using (AuthRepository _repo = new AuthRepository())
            {
                IdentityUser user = await _repo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "user"));

            context.Validated(identity);

        }
    }
}