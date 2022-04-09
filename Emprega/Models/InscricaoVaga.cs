using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class InscricaoVaga
    {
        public int Id { get; set; }
        [Display(Name = "Candidato")]
        public int IdCandidato { get; set; }
        [Display(Name = "Vaga")]
        public int IdVaga { get; set; }
        [Display(Name = "Data de Pulicação")]
        public DateTime Data { get; set; }
        [Display(Name = "Status da Vaga")]
        public int IdStatus { get; set; }

        [Display(Name = "Candidato")]
        public virtual Candidato IdCandidatoNavigation { get; set; } = null!;
        [Display(Name = "Status Inscrição")]
        public virtual InscricaoStatus IdStatusNavigation { get; set; } = null!;
        [Display(Name = "Vaga")]
        public virtual Vaga IdVagaNavigation { get; set; } = null!;
    }
}
