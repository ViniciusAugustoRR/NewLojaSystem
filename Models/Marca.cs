using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaSystem.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }
        [Required]
        [Display(Name = "Nome da Marca")]
        public string? NomeMarca { get; set; }

        public ICollection<Equipamento>? Equipamentos { get; set; }
    }
}
