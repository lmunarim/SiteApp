using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using serviceApi.Providers;

[assembly: OwinStartup(typeof(serviceApi.Startup))]

namespace serviceApi
{
    public class Startup
    {
            public void Configuration(IAppBuilder app)
            {
                HttpConfiguration config = new HttpConfiguration();

                ConfigureOAuth(app);

                WebApiConfig.Register(config);
                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
                app.UseWebApi(config);
            }

            public void ConfigureOAuth(IAppBuilder app)
            {
                OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(1), // expiração em 1 minuto;
                    Provider = new ApplicationOAuthProvider()
                };

                // Token Generation
                app.UseOAuthAuthorizationServer(OAuthServerOptions);
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            }
    }
}
