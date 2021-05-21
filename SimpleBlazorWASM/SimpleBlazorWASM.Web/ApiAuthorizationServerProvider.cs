using System;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

namespace SimpleBlazorWASM.Web
{
    public class ApiAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); //   
            return Task.CompletedTask;
        }

        /// <summary>
        /// match endpoint is called before Validate Client Authentication. we need
        /// to allow the clients based on domain to enable requests
        /// the header
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task MatchEndpoint(OAuthMatchEndpointContext context)
        {
            SetCORSPolicy(context.OwinContext);
            if (context.Request.Method == "OPTIONS")
            {
                context.RequestCompleted();
                return Task.FromResult(0);
            }

            return base.MatchEndpoint(context);
        }


        /// <summary>
        /// add the allow-origin header only if the origin domain is found on the     
        /// allowedOrigin list
        /// </summary>
        /// <param name="context"></param>
        private void SetCORSPolicy(IOwinContext context)
        {
            string allowedUrls = ConfigurationManager.AppSettings["allowedOrigins"];

            if (!String.IsNullOrWhiteSpace(allowedUrls))
            {
                var list = allowedUrls.Split(',');
                if (list.Length > 0)
                {

                    var origin = context.Request.Headers.Get("Origin");
                    var found = list.Any(item => item == origin);
                    if (found)
                    {
                        context.Response.Headers.Add("Access-Control-Allow-Origin",
                                                     new[] { origin });
                    }
                }

            }
            context.Response.Headers.Add("Access-Control-Allow-Headers",
                                   new[] { "Authorization", "Content-Type", "Accept" });
            context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "OPTIONS", "POST", "GET", "PUT" });

        }


        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "admin" && context.Password == "admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Hi Admin"));
                context.Validated(identity);
            }
            else if (context.UserName == "user" && context.Password == "user")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Hi User"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
            }

            return Task.CompletedTask;
        }
    }
}