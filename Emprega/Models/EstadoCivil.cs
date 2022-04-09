using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            Candidato = new HashSet<Candidato>();
        }

        public int Id { get; set; }
        [Display(Name = "Estado Cívil")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Candidato")]
        public virtual ICollection<Candidato> Candidato { get; set; }
    }
}
