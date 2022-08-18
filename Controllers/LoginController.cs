using LojaSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LojaSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            //if(!string.IsNullOrEmpty(Token)) GetClaimsFromToken(Token);
            return View();
        }

        [HttpPost]
        public ActionResult VerifyToken([FromBody]UserToken userToken)
        {
            if (GetClaimsFromToken(userToken._UserToken) != 0) {

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index");
        }

        private int GetClaimsFromToken(string _token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(_token);

                var NivelAcesso = int.Parse(jwt.Claims.First(claim => claim.Type == "UserAcesso").Value);
        
                HttpContext.Session.SetInt32("_UserAcesso", NivelAcesso);
                HttpContext.Session.SetString("_UserName", jwt.Claims.First(claim => claim.Type == "UserName").Value);
                HttpContext.Session.SetInt32("_UserId", int.Parse(jwt.Claims.First(claim => claim.Type == "UserId").Value));

                return NivelAcesso;
            }
            catch(Exception e)
            {
                //throw e;
                return 0;
            }
            
        }
        


        [HttpGet]
        public JsonResult VerifyLogin(string user, string password)
        {
            var x = user;
            var y = password;
            



            return Json(new { erro = true, mensagem = "" });
        }

    }
}
