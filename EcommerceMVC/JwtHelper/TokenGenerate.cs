using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using EcommerceMVC.AppSetting;

namespace EcommerceMVC.JwtHelper
{

    public class TokenGenerate
    {
        private readonly IOptions<JwtSetting> _jwtSetting;
        public TokenGenerate(IOptions<JwtSetting> jwtSetting)
        {
            _jwtSetting = jwtSetting;
        }
        public string GenerateJwtToken(string name, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Value.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Role, role)
            };


            var token = new JwtSecurityToken(
                issuer: _jwtSetting.Value.Issuer,
                audience: _jwtSetting.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_jwtSetting.Value.ExpireMinutes)),
                signingCredentials: credentials
            );
            return tokenHandler.WriteToken(token);
        }

    }

    //with Direct IConfiguration Not IOptions
    //public class TokenGenerate
    //{
    //    private readonly IConfiguration _jwtSetting;
    //    public TokenGenerate(IConfiguration jwtSetting)
    //    {
    //        _jwtSetting = jwtSetting;   
    //    }
    //    public string GenerateJwtToken(string name, string role)
    //    {
    //        var tokenHandler = new JwtSecurityTokenHandler();

    //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting["JwtSetting:Key"]));
    //        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

    //        var claims = new List<Claim>
    //        {
    //            new Claim(ClaimTypes.Name, name),
    //            new Claim(ClaimTypes.Role, role)
    //        };


    //        var token = new JwtSecurityToken(
    //            issuer: _jwtSetting["JwtSetting:Issuer"],
    //            audience: _jwtSetting["JwtSetting:Audience"],
    //            claims : claims,
    //            expires: DateTime.UtcNow.AddMinutes(double.Parse(_jwtSetting["JwtSetting:ExpireMinutes"])),
    //            signingCredentials: credentials
    //        );
    //        return tokenHandler.WriteToken(token);
    //    }

    //}
}
