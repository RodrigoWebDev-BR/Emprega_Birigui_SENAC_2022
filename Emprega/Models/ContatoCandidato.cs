using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class ContatoCandidato
    {
        public int Id { get; set; }
        public int IdCandidato { get; set; }
        public int IdTipoContato { get; set; }
        public string Contato { get; set; } = null!;

        [Display(Name = "Candidato")]
        public virtual Candidato IdCandidatoNavigation { get; set; } = null!;
        [Display(Name = "Tipo de Contato")]
        public virtual TipoContato IdTipoContatoNavigation { get; set; } = null!;
    }
}
