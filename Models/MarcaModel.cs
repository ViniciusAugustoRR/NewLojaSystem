using System.ComponentModel.DataAnnotations;

namespace LojaSystem.Models
{
    public class MarcaModel
    {
        [Key]
        public int IdMarca { get; set; }
        public string? NomeMarca { get; set; }

    }
}
