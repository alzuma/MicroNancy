using Nancy.ErrorHandling;
using Nancy.ViewEngines;
using System;
using Nancy;

namespace GateWay.app.handles
{
    public class PageNotFoundHandler : DefaultViewRenderer, IStatusCodeHandler
    {
        public PageNotFoundHandler(IViewFactory factory) : base(factory)
        {
        }

        void IStatusCodeHandler.Handle(HttpStatusCode statusCode, NancyContext context)
        {
            if (context.ResolvedRoute.Description.Path.Contains(".")) return;

            var response = RenderView(context, "index");
            response.StatusCode = HttpStatusCode.OK;
            context.Response = response;
        }

        bool IStatusCodeHandler.HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound;
        }
    }
}
