using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class NivelEscolaridade
    {
        public NivelEscolaridade()
        {
            Candidato = new HashSet<Candidato>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Candidato> Candidato { get; set; }
    }
}
