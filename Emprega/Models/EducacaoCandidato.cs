using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class EducacaoCandidato
    {
        public int Id { get; set; }
        [Display(Name = "Candidato")]
        public int IdCandidato { get; set; }
        [Display(Name = "Curso")]
        public string Curso { get; set; } = null!;
        [Display(Name = "Instituição de Ensino")]
        public string Instituicao { get; set; } = null!;
        [Display(Name = "Data de Início")]
        public DateTime Inicio { get; set; }
        [Display(Name = "Data de Fim")]
        public DateTime? Fim { get; set; }

        [Display(Name = "Candidato")]
        public virtual Candidato IdCandidatoNavigation { get; set; } = null!;
    }
}
