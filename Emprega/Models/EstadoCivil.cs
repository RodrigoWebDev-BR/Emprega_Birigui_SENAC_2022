using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            Candidato = new HashSet<Candidato>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Candidato> Candidato { get; set; }
    }
}
