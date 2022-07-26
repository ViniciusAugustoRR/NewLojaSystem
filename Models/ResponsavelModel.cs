using System.ComponentModel.DataAnnotations;

namespace LojaSystem.Models
{
    public class ResponsavelModel
    {
        [Key]
        public int IdResponsavel { get; set; }
        public string? NameResponsavel { get; set; }
        public string? CategoriaResponsavel { get; set; }

    }
}
