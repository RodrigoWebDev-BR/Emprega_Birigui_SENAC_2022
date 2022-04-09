using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class ExperienciaCandidato
    {
        public int Id { get; set; }
        [Display(Name = "Candidato")]
        public int IdCandidato { get; set; }
        [Display(Name = "Empresa")]
        public string Empresa { get; set; } = null!;
        [Display(Name = "Data de Admissão")]
        public DateTime Admissao { get; set; }
        [Display(Name = "Data de Demissão")]
        public DateTime? Demissao { get; set; }
        [Display(Name = "Cargo")]
        public string Cargo { get; set; } = null!;
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Display(Name = "Candidato")]
        public virtual Candidato IdCandidatoNavigation { get; set; } = null!;
    }
}
