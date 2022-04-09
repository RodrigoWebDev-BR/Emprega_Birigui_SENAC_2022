using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class ContatoCandidato
    {
        public int Id { get; set; }
        [Display(Name = "Candidato")]
        public int IdCandidato { get; set; }
        [Display(Name = "Tipo de Contato")]
        public int IdTipoContato { get; set; }
        [Display(Name = "Contato")]
        public string Contato { get; set; } = null!;

        [Display(Name = "Candidato")]
        public virtual Candidato IdCandidatoNavigation { get; set; } = null!;
        [Display(Name = "Tipo de Contato")]
        public virtual TipoContato IdTipoContatoNavigation { get; set; } = null!;
    }
}
