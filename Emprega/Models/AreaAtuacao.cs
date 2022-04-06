using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class AreaAtuacao
    {
        public AreaAtuacao()
        {
            Candidato = new HashSet<Candidato>();
            Empresa = new HashSet<Empresa>();
            Vaga = new HashSet<Vaga>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Candidato> Candidato { get; set; }
        public virtual ICollection<Empresa> Empresa { get; set; }
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
