using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class VagaBeneficio
    {
        public int Id { get; set; }
        public int IdVaga { get; set; }
        public int IdBeneficio { get; set; }

        public virtual Beneficio IdBeneficioNavigation { get; set; } = null!;
        public virtual Vaga IdVagaNavigation { get; set; } = null!;
    }
}
