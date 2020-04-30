using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using shopWeb.Models;

namespace shopWeb.Services
{
    public static class TokenService
    {
        public static string Generate(Usuario usuario)
        {
           var tokenHandler = new JwtSecurityTokenHandler();
           var token = tokenHandler.CreateToken(getTokenDescriptor(usuario));

           return tokenHandler.WriteToken(token);
        }

        private static SecurityTokenDescriptor getTokenDescriptor(Usuario usuario)
        {
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                //criação do claims
                Subject = new ClaimsIdentity(new []
                {
                    new Claim(ClaimTypes.Name , usuario.Name),
                    new Claim(ClaimTypes.Role , usuario.Roles), 
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Settings.getKey()),
                    SecurityAlgorithms.HmacSha256Signature)

            };

            return tokenDescriptor;
        }
        
    }
}