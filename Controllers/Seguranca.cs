using LojaSystem.Helpers;
using LojaSystem.DAO;
using LojaSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace LojaSystem.Controllers
{
    public class Seguranca : Controller
    {
        private IConfiguration _Config;
        private LoginDAO _LoginDAO;

        private int _RespAcesso = 0;
        private string _RespName = "";
        private int _RespId = 0;
        public Seguranca(IConfiguration Configuration)
        {
            _Config = Configuration;
            _LoginDAO = new LoginDAO(_Config.GetConnectionString("DBConnections"));
        }

        [HttpPost]
        public JsonResult Login([FromBody] UserToken loginUser)
        {
            bool result = ValidateUser(loginUser);

            if (result)
            {
                var tokenString = GerarTokenJWT();
                
                return Json(new { error = false,  token = tokenString });
            }

            return Json(new { error = true, errorMessage = "Usuário ou Senha Incorretos"});

        }
        public IActionResult TokenVerify([FromBody] string jwt)
        {
            return Ok();
        }


        private string GerarTokenJWT()
        {
            var _issuer = _Config["Jwt:Issuer"];
            var _audience = _Config["Jwt:Audience"];
            var _expires = DateTime.UtcNow.AddMinutes(35);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["Jwt:Key"]));
            var _credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new ClaimsIdentity();
            //Adding User Info to Token
            claims.AddClaim(new Claim("UserAcesso", _RespAcesso.ToString()));
            claims.AddClaim(new Claim("UserName", _RespName.ToString()));
            claims.AddClaim(new Claim("UserId", _RespId.ToString()));
            //=========================
            claims.AddClaim(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.AddClaim(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor { 
                Issuer = _issuer,
                Audience = _audience,
                Subject = claims,
                Expires  = _expires,
                SigningCredentials = _credentials
            });
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
        private bool ValidateUser(UserToken user)
        {
            try
            {
                if (user.UserName == _Config["Session:mainUser"]
                    && user.Password == _Config["Session:mainPassword"])
                {
                    _RespAcesso = 4;
                    _RespName = "Admin";
                    _RespId = 0;
                    return true;
                }
                
                var resp = _LoginDAO.VerifyLogin(user.UserName, user.Password);
                if (resp.NivelResponsavelId > 0)
                {
                    _RespAcesso = resp.NivelResponsavelId;
                    _RespName = resp.Nome;
                    _RespId = resp.IdResponsavel;
                    return true;
                }
                
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static long ToUnixEpochDate(DateTime date) =>
            (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        


    /*ALTER PROCEDURE LS_LOGIN_VERIFY
        @USER VARCHAR(50),
        @PASSWORD VARCHAR(50)
        AS
        BEGIN

            IF(SELECT COUNT(*) 
                FROM Responsaveis 
                WHERE
                Responsaveis.Login = @USER
                AND Responsaveis.Senha = (SELECT HashBytes('MD5', CONVERT(VARBINARY(MAX), CONVERT(VARCHAR, @PASSWORD))))) < 1 
            BEGIN

                SELECT 
                    IdResponsavel,
                    NivelResponsavelId,
                    Nome
                FROM Responsaveis
                WHERE Login = @USER

            END

    END*/
    }
}
