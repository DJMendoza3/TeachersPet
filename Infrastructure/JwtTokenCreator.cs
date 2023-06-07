using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TeachersPet.Infrastructure
{
    public class JwtTokenCreator
    {
        private readonly JwtSetting _jwtSetting;

        public JwtTokenCreator(JwtSetting jwtSetting)
        {
            _jwtSetting = jwtSetting;
        }

        public string Generate(string name, int userId) 
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _jwtSetting.Issuer,
                _jwtSetting.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(_jwtSetting.MinutesToExpiration),
                signingCredentials: creds
            );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}