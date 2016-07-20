using GateWay.app.interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GateWay.server.authentication.modules
{
    public class LoginModule : Nancy.NancyModule
    {
        private readonly IAppConfig _appConfig;

        public LoginModule(IAppConfig appConfig)
        {
            _appConfig = appConfig;

            Get["/login"] = _ =>
            {
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfig.SecretKey));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Role, "Administrator"),
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim(ClaimTypes.Name, "John")
                };

                var issued = DateTime.UtcNow;
                var expires = DateTime.UtcNow.AddDays(1);

                var token = new JwtSecurityToken(_appConfig.TokenIssuer, "GateWay Inc", claims, issued, expires, signingCredentials);

                var handler = new JwtSecurityTokenHandler();
                return handler.WriteToken(token);
            };
        }
    }
}
