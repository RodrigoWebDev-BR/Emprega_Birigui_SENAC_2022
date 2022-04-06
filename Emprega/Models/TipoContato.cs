using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class TipoContato
    {
        public TipoContato()
        {
            ContatoCandidato = new HashSet<ContatoCandidato>();
            ContatoEmpresa = new HashSet<ContatoEmpresa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<ContatoCandidato> ContatoCandidato { get; set; }
        public virtual ICollection<ContatoEmpresa> ContatoEmpresa { get; set; }
    }
}
