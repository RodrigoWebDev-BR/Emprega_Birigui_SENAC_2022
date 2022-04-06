using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class InscricaoStatus
    {
        public InscricaoStatus()
        {
            InscricaoVaga = new HashSet<InscricaoVaga>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Cor { get; set; } = null!;

        public virtual ICollection<InscricaoVaga> InscricaoVaga { get; set; }
    }
}
