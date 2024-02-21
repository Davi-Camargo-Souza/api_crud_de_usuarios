using Microsoft.IdentityModel.Tokens;
using SeboScrob.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SeboScrob.WebAPI.Services
{
    public class TokenService
    {
        public static string Generate(UserEntity user)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = GetPrivateKey();

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials
            };


            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims (UserEntity user)
        {
            var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim(ClaimTypes.Email, user.Email)
                });

            return claims;
        }

        // essa chave não vai ficar armazenada aqui e não será a chave final.
        // ela só está aqui para fim de testes de implementação do token.
        public static byte[] GetPrivateKey()
        {
            var key = Encoding.Default.GetBytes("&*t#F342$e%g(U9x@D#7f^8h%j&*k(L56m");
            return key;
        }
    }
}
