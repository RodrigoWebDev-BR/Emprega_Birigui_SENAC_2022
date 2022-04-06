using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class InscricaoVaga
    {
        public int Id { get; set; }
        public int IdCandidato { get; set; }
        public int IdVaga { get; set; }
        public int IdStatus { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; } = null!;
        public virtual InscricaoStatus IdStatusNavigation { get; set; } = null!;
        public virtual Vaga IdVagaNavigation { get; set; } = null!;
    }
}
