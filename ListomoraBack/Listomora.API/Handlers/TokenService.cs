using Listomora.Application.Contracts.Persistence.Dtos;
using Listomora.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Listomora.API.Handlers
{
    public class TokenService
    {
        private readonly IConfiguration m_Config;

        public TokenService(IConfiguration config)
        {
            m_Config = config;
        }

        public string GenerateJwtToken(UserForToken user)
        {
            // Création d'un objet de securité avec les informations
            // a stocker dans le token (Pas d'info sensibles !!!)
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };


            // Crédentials pour signé le token (Clef + l'algo)
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(m_Config["Jwt:Key"]!));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Génération du token
            JwtSecurityToken token = new JwtSecurityToken(
                m_Config["Jwt:Issuer"],
                m_Config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(6),
                signingCredentials: creds
            );

            // Export du token sous forme de chaine de caractere
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
