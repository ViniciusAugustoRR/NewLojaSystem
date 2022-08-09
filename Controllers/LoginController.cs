using Microsoft.AspNetCore.Mvc;

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
            return View();
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
