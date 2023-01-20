using DatingApp.Entities;
using DatingAppWeb.DTOs;
using DatingAppWeb.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DatingAppWeb.Services
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        public TokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetToken(LoginDTO userDTO)
        {
           var authClaims = new List<Claim>
           {
             new Claim(JwtRegisteredClaimNames.Email,userDTO.UserName)
           };
            var key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]));

            var token = new JwtSecurityToken(
                claims:authClaims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials :new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
