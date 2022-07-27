using System.ComponentModel.DataAnnotations;

namespace LojaSystem.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Display(Name = "Nome Completo")]
        public string? Nome { get; set; }
        [Display(Name = "Apelido")]
        public string? Apelido { get; set; }
        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }
        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }
        [Display(Name = "E-mail")]
        public string? Email { get; set; }
    }
}
