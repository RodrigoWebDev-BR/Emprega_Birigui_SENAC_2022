using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class HorarioTrabalho
    {
        public int Id { get; set; }
        [Display(Name = "Vaga")]
        public int IdVaga { get; set; }
        [Display(Name = "Dia da Semana")]
        public string DiaSemana { get; set; } = null!;
        [Display(Name = "Horário Início")]
        public TimeOnly HorarioInicial { get; set; }
        [Display(Name = "Horário Término")]
        public TimeOnly HorarioFinal { get; set; }

        [Display(Name = "Vaga")]
        public virtual Vaga IdVagaNavigation { get; set; } = null!;
    }
}
