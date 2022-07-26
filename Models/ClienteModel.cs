using System.ComponentModel.DataAnnotations;

namespace LojaSystem.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

    }

}
