using LojaSystem.Helpers;
using LojaSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LojaSystem.Controllers
{
    public class Seguranca : Controller
    {
        private IConfiguration _Config;
        private ConnHelper Conn;

        public Seguranca(IConfiguration Configuration)
        {
            _Config = Configuration;
            Conn = new ConnHelper(_Config.GetConnectionString("HOMConnection"));
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

                //bool doesUserExists = Conn.ExecQueryToBool(
                // @"IF(SELECT COUNT(1) 
	               //     FROM USUARIO 
	               //     WHERE
	               //     USU_CPF_CNPJ = @CPF_CNPJ
	               //     and USU_SENHA = 
	               //     (SELECT HashBytes('MD5', CONVERT(VARBINARY(MAX), CONVERT(VARCHAR, @USU_SENHA)))) AND USU_CONFIRMACAO_EMAIL = 1) > 0
                //    BEGIN
	               //     SELECT 1 AS RESULT
                //    END
                //    ELSE
                //    BEGIN
                //        SELECT 0 AS RESULT
                //    END
                //    ",
                // new List<SqlParameter> {
                //     new SqlParameter("@CPF_CNPJ", user.UserName),
                //      new SqlParameter("@USU_SENHA", user.Password)
                // });

                return doesUserExists;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
