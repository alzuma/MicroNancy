using GateWay.server.authentication.components;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Owin;
using Nancy.TinyIoc;
using System.Security.Claims;

namespace GateWay.app
{
    public class Bootstrapper : Nancy.DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            Conventions.ViewLocationConventions.Insert(0, (viewName, model, context) =>
            {
                return string.Concat("pub/", viewName);
            });
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            var owinEnvironment = context.GetOwinEnvironment();

            var principal = owinEnvironment?["server.User"] as ClaimsPrincipal;

            if (principal == null) return;

            context.CurrentUser = new GateWayUser(principal.Identity.Name, principal.Claims);
        }
    }
}
