using LojaSystem.Helpers;
using LojaSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LojaSystem.Controllers
{
    public class Seguranca : ControllerBase
    {
        private IConfiguration _Config;

        public IActionResult Login([FromBody] UserToken loginUser)
        {
            bool result = ValidateUser(loginUser);

            if (result)
            {
                var tokenString = GerarTokenJWT();
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }
        public IActionResult TokenVerify([FromBody] string jwt)
        {
            return Ok();
        }

        public Seguranca(IConfiguration Configuration)
        {
            _Config = Configuration;
        }
        private string GerarTokenJWT()
        {
            var _issuer = _Config["Jwt:Issuer"];
            var _audience = _Config["Jwt:Audience"];
            var _expires = DateTime.Now.AddMinutes(30);
            //var expiry = TimeSpan.FromDays(1);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["Jwt:Key"]));
            var _credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: _issuer, audience: _audience,
                expires: _expires, signingCredentials: _credentials);
            var tokenHandler = new JwtSecurityTokenHandler();

            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        private bool ValidateUser(UserToken user)
        {
            try
            {
                if (user.UserName == _Config["Session:mainUser"] 
                    && user.Password == _Config["Session:mainPassword"])
                    return true;
                
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
