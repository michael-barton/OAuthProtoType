using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using OAuthAttempt.ResourceServer;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace OAuthAttempt.ResourceServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }

    
}