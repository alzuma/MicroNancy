using Nancy.Bootstrapper;
using Nancy.TinyIoc;

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
    }
}
