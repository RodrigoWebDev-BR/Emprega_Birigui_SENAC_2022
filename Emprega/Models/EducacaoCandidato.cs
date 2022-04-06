using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class EducacaoCandidato
    {
        public int Id { get; set; }
        public int IdCandidato { get; set; }
        public string Curso { get; set; } = null!;
        public string Instituicao { get; set; } = null!;
        public DateOnly Inicio { get; set; }
        public DateOnly? Fim { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; } = null!;
    }
}
