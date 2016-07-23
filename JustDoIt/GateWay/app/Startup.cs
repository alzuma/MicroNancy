using System;
using GateWay.server.authentication.components;
using Owin;
using Owin.StatelessAuth;

namespace GateWay.app
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new AppConfig();

            app.RequiresStatelessAuth(new TokenValidator(config),
                Options());

            app.UseNancy();
        }

        private StatelessAuthOptions Options()
        {
            return new StatelessAuthOptions
            {
                IgnorePaths = new[]
                                {
                        "/",
                        "/fonts/*,*",
                        "/scripts/*.js",
                        "/content/*.*",
                        "/favicon.ico",
                        "/login",
                        "/admin"
                    }
            }           
        }
    }
}
