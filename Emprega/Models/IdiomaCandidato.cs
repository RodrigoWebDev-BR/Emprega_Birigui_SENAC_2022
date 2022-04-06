using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class IdiomaCandidato
    {
        public int Id { get; set; }
        public int IdIdioma { get; set; }
        public string Nivel { get; set; } = null!;

        public virtual Idioma IdIdiomaNavigation { get; set; } = null!;
    }
}
