using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class NivelEscolaridade
    {
        public NivelEscolaridade()
        {
            Candidato = new HashSet<Candidato>();
        }

        public int Id { get; set; }
        [Display(Name = "Nível de Escolaridade")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Candidato")]
        public virtual ICollection<Candidato> Candidato { get; set; }
    }
}
