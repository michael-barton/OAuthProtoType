using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using OAuthAttempt;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace OAuthAttempt
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<OAuthDbContext>(() => new OAuthDbContext());
            app.CreatePerOwinContext<UserManager<IdentityUser>>(CreateManager);

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/oauth/token"),
                Provider = new MyOAuthAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
#if DEBUG
                AllowInsecureHttp = true,
#endif
            });

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private static UserManager<IdentityUser> CreateManager(
        IdentityFactoryOptions<UserManager<IdentityUser>> options,
        IOwinContext context)
        {
            var userStore =
                new UserStore<IdentityUser>(context.Get<OAuthDbContext>());

            var manager =
                new UserManager<IdentityUser>(userStore);

            return manager;
        }
    }
}