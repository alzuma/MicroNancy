using Owin.StatelessAuth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace GateWay.server.authentication.components
{
    public class TokenValidator : ITokenValidator
    {
        private readonly string _secretKey;

        public TokenValidator(string secretKey)
        {
            _secretKey = secretKey;
        }

        private TokenValidationParameters TokenValidationParameters()
        {
            var validationParameters = new TokenValidationParameters();
            var validAudiences = new List<string>();
            var issuerSigningKeys = new List<SymmetricSecurityKey>();

            issuerSigningKeys.Add(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey)));
            validAudiences.Add("GateWay Inc");

            validationParameters.ValidAudiences = validAudiences;
            validationParameters.IssuerSigningKeys = issuerSigningKeys;
            validationParameters.AuthenticationType = "JWT";
            validationParameters.ValidIssuer = "GateWay";

            return validationParameters;
        }

        public ClaimsPrincipal ValidateUser(string token)
        {
            if (token.IndexOf("Bearer ") >= 0)
            {
                token = token.Remove(0, "Bearer ".Length);
            }

            var th = new JwtSecurityTokenHandler();
            var jwtToken = th.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
            {
                throw new ArgumentOutOfRangeException(nameof(token), "Invalid token");
            }

            SecurityToken validatedToken;
            var claimsPrincipal = th.ValidateToken(token, TokenValidationParameters(), out validatedToken);
            return claimsPrincipal;
        }
    }
}
