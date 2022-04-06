using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class Beneficio
    {
        public Beneficio()
        {
            VagaBeneficio = new HashSet<VagaBeneficio>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<VagaBeneficio> VagaBeneficio { get; set; }
    }
}
