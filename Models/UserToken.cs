using System.ComponentModel.DataAnnotations;

namespace LojaSystem.Models
{
    public class UserToken
    {
        [Key]
        public int IdUserToken { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }

}
