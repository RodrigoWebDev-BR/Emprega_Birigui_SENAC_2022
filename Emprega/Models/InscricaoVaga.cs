using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class InscricaoVaga
    {
        public int Id { get; set; }
        public int IdCandidato { get; set; }
        public int IdVaga { get; set; }
        public DateTime Data { get; set; }
        public int IdStatus { get; set; }

        [Display(Name = "Candidato")]
        public virtual Candidato IdCandidatoNavigation { get; set; } = null!;
        [Display(Name = "Status")]
        public virtual InscricaoStatus IdStatusNavigation { get; set; } = null!;
        [Display(Name = "Vaga")]
        public virtual Vaga IdVagaNavigation { get; set; } = null!;
    }
}
