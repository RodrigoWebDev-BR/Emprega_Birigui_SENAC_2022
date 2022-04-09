using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class Idioma
    {
        public Idioma()
        {
            IdiomaCandidato = new HashSet<IdiomaCandidato>();
        }

        public int Id { get; set; }
        [Display(Name = "Idioma")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Idioma Candidato")]
        public virtual ICollection<IdiomaCandidato> IdiomaCandidato { get; set; }
    }
}
