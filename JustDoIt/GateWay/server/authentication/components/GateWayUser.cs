using Nancy.Security;
using System.Collections.Generic;
using System.Security.Claims;

namespace GateWay.server.authentication.components
{
    public class GateWayUser : IUserIdentity
    {
        private readonly string _userName;
        private readonly List<string> _claims;
        public GateWayUser(string userName, IEnumerable<Claim> claims)
        {
            _userName = userName;
            _claims = new List<string>();
            foreach (var claim in claims)
            {
                if (claim.Type == ClaimTypes.Role)
                {
                    _claims.Add(claim.Value);
                }
            }
        }

        public IEnumerable<string> Claims => _claims;
        public string UserName => _userName;
    }
}
