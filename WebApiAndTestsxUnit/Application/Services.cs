using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebApiAndTestsxUnit.Application
{
    public static class Services
    {
        public static string Key;

        public static string GenerateToke()
        {
           

            var symmetricKey = Convert.FromBase64String(Key);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim("Isaias", "test")
        }),

                Expires = now.AddMinutes(Convert.ToInt32(TimeSpan.FromMinutes(5).Minutes)),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;


        }

    }
}
