using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaSystem.Models
{
    public class Equipamento
    {
        [Key]
        public int IdEquipamento { get; set; }
        public string? NumeroSerie { get; set; }
        public string? Nome { get; set; }
        public MarcaModel? MarcaEquipamento { get; set; }
        public string? Acessorios { get; set; }

    }
}
