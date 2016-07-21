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
                new StatelessAuthOptions
                {
                    IgnorePaths = new[]
                    {
                        "/",
                        "/favicon.ico",
                        "/login",
                        "/admin"
                    }
                });

            app.UseNancy();
        }
    }
}
