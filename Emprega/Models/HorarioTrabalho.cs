using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class HorarioTrabalho
    {
        public int Id { get; set; }
        public int IdVaga { get; set; }
        public string DiaSemana { get; set; } = null!;
        public TimeOnly HorarioInicial { get; set; }
        public TimeOnly HorarioFinal { get; set; }

        public virtual Vaga IdVagaNavigation { get; set; } = null!;
    }
}
