using System.ComponentModel.DataAnnotations;

namespace LojaSystem.Models
{
    public class NivelResponsavel
    {
        [Key]
        public int IdNivel { get; set; }
        [Display(Name = "Nome do Nível")]
        public string? Nivel { get; set; }

        public ICollection<Responsavel>? Responsaveis { get; set; }
    }
}
