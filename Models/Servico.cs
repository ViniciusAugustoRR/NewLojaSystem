using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaSystem.Models
{
    public class Servico
    {

        [Key]
        public int IdServico { get; set; }
        [Display(Name = "Data Inicial do Serviço")]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Data Final do Serviço")]
        public DateTime DataFinal { get; set; }


        [Display(Name = "Cliente")]
        public Cliente? ClienteServico { get; set; }
        [Display(Name = "Cliente")]
        [ForeignKey("ClienteServico")]
        public int ClienteId { get; set; }

        [Display(Name = "Equipamento")]
        public Equipamento? EquipamentoServico { get; set; }
        [ForeignKey("EquipamentoServico")]
        [Display(Name = "Equipamento")]
        public int EquipamentoServicoId { get; set; }

        [Display(Name="Responsável")]
        public Responsavel? ResponsavelServico { get; set; }
        [ForeignKey("ResponsavelServico")]
        [Display(Name = "Responsável")]
        public int ResponsavelServicoId { get; set; }

    }
}
