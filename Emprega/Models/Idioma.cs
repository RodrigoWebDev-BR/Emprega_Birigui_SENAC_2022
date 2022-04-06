using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class Idioma
    {
        public Idioma()
        {
            IdiomaCandidato = new HashSet<IdiomaCandidato>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<IdiomaCandidato> IdiomaCandidato { get; set; }
    }
}
