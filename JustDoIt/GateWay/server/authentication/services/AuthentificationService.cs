using GateWay.server.authentication.interfaces;
using GateWay.server.db.entities;
using System.Collections.Generic;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using GateWay.app.interfaces;

namespace GateWay.server.authentication.services
{
    class AuthentificationService : IAuthentificationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAppConfig _appConfig;

        public AuthentificationService(IUserRepository userRepository, IAppConfig appConfig)
        {
            _userRepository = userRepository;
            _appConfig = appConfig;
        }

        public void AddAdminUser()
        {
            var checkUser = _userRepository.FindByLogin("admin");

            if (checkUser != null) return;

            var user = new UserEntity
            {
                Login = "admin",
                Name = "Kristaps Vītoliņš",
                Password = "qwerty",
                Role = new List<string> { "Admin", "User" }
            };
            _userRepository.AddUser(user);
        }

        public string GenerateJwtToken()
        {
            var user = _userRepository.FindByLogin("admin");

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfig.SecretKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            foreach (var claim in user.Role)
            {
                claims.Add(new Claim(ClaimTypes.Role, claim));
            }

            var issued = DateTime.UtcNow;
            var expires = DateTime.UtcNow.AddDays(1);

            var token = new JwtSecurityToken(_appConfig.TokenIssuer, "GateWay Inc", claims, issued, expires, signingCredentials);

            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}
