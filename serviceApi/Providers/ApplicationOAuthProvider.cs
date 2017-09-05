using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace serviceApi.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            if (context.UserName.ToLower() == "teste" && context.Password == "123456")
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Country, "Brasil"));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Dev"));

                IdentityUser usuario = new IdentityUser { UserName = context.UserName, PasswordHash = context.Password };

                var tichet = new AuthenticationTicket(identity, GetProperties(usuario, identity.Claims));

                context.Validated(tichet);
            }
            else
            {
                context.SetError("invalid_grant", "Usuario inválido");
                return;
            }
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
             return Task.FromResult<object>(null);
        }
        private static AuthenticationProperties GetProperties(IdentityUser usuario, IEnumerable<Claim> claims)
        {
            IDictionary<string, string> data = new Dictionary<string, string>();
            data.Add(new KeyValuePair<string, string>("claims", string.Join(",", claims)));
            return new AuthenticationProperties(data);
        }
    }
}