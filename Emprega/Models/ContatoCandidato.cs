using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class ContatoCandidato
    {
        public int Id { get; set; }
        public int IdCandidato { get; set; }
        public int IdContato { get; set; }
        public string Contato { get; set; } = null!;

        public virtual Candidato IdCandidatoNavigation { get; set; } = null!;
        public virtual TipoContato IdContatoNavigation { get; set; } = null!;
    }
}
