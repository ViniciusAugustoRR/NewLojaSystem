using System.ComponentModel.DataAnnotations;

namespace LojaSystem.Models
{
    public class ServicoModel
    {
        [Key]
        public int IdServico { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }

        public ClienteModel? ClienteServico { get; set; }
        public ResponsavelModel? ResponsavelServico { get; set; }
        public Equipamento? EquipamentoService { get; set; }

    }
}
