using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class IdiomaCandidato
    {
        public int Id { get; set; }
        [Display(Name = "Idioma")]
        public int IdIdioma { get; set; }
        [Display(Name = "Nível")]
        public string Nivel { get; set; } = null!;
        [Display(Name = "Idioma Candidato")]
        public virtual Idioma IdIdiomaNavigation { get; set; } = null!;
    }
}
