﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaSystem.Models
{
    public class Responsavel
    {

        [Key]
        public int IdResponsavel { get; set; }

        [Display(Name = "Nome de Responsável")]
        public string? Nome { get; set; }

        [Display(Name = "E-mail")]
        public string? Email { get; set; }


        [Display(Name = "Login")]
        [MaxLength(50)]
        public string? Login { get; set; }

        [Display(Name = "Senha")]
        [MaxLength(50)]
        public string? Senha { get; set; }


        [Display(Name = "Nível")]
        public NivelResponsavel? NivelResponsavel { get; set; }

        [ForeignKey("NivelResponsavel")]
        [Display(Name = "Nível")]
        public int NivelResponsavelId { get; set; }

        public ICollection<Servico>? Servicos { get; set; }
    }
}
