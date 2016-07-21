using GateWay.server.authentication.interfaces;
using Nancy;

namespace GateWay.server
{
    public class IndexModule : NancyModule
    {
        private readonly IUserRepository _userRepository;

        public IndexModule(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            Get["/"] = _ => View["index"];

            Get["/admin"] = x =>
            {
                var user = _userRepository.FindByLogin("admin");
                return Response.AsJson(user);
            };
        }
    }
}
