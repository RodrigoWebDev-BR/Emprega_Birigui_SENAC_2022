using System;
using System.Collections.Generic;

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
        public string Nome { get; set; } = null!;
        public string Uf { get; set; } = null!;

        public virtual ICollection<Candidato> Candidato { get; set; }
        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
