using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class TipoContrato
    {
        public TipoContrato()
        {
            Vaga = new HashSet<Vaga>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
