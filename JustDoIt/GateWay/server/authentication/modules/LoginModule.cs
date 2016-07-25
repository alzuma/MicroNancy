using GateWay.server.authentication.interfaces;
using Nancy;

namespace GateWay.server.authentication.modules
{
    public class LoginModule : Nancy.NancyModule
    {
        private readonly IAuthentificationService _authentificationService;

        public LoginModule(IAuthentificationService authentificationService) : base("api/gateway")
        {
            _authentificationService = authentificationService;

            Get["/login"] = _ =>
            {                
                return Response.AsJson(new { token = _authentificationService.GenerateJwtToken() });
            };
        }
    }
}
