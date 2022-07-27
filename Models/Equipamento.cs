using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaSystem.Models
{
    public class Equipamento
    {
        [Key]
        public int IdEquipamento { get; set; }

        [Display(Name="Número de Série")]
        public string? NumeroSerie { get; set; }
        [Display(Name = "Nome")]
        public string? Nome { get; set; }
        [Display(Name = "Acessórios")]
        public string? Acessorios { get; set; }
        [Display(Name = "Marca")]
        public Marca? MarcaEquipamento { get; set; }
        [ForeignKey("MarcaEquipamento")]
        [Display(Name = "Marca")]
        public int MarcaFK { get; set; }
    }

}
