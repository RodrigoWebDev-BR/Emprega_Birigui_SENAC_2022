using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Candidato = new HashSet<Candidato>();
            Empresa = new HashSet<Empresa>();
        }

        public int Id { get; set; }
        [Display(Name = "Cidade")]
        public string Nome { get; set; } = null!;
        [Display(Name = "UF")]
        public string Uf { get; set; } = null!;

        [Display(Name = "Candidato")]
        public virtual ICollection<Candidato> Candidato { get; set; }
        [Display(Name = "Empresa")]
        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
