using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class ExperienciaCandidato
    {
        public int Id { get; set; }
        public int IdCandidato { get; set; }
        public string Empresa { get; set; } = null!;
        public DateOnly Admissao { get; set; }
        public DateOnly? Demissao { get; set; }
        public string Cargo { get; set; } = null!;
        public string? Descricao { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; } = null!;
    }
}
