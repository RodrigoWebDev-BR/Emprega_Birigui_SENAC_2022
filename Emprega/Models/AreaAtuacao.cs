using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Área Atuação")]
        public string Nome { get; set; } = null!;

        [Display(Name = "candidato")]
        public virtual ICollection<Candidato> Candidato { get; set; }
        [Display(Name = "Empresa")]
        public virtual ICollection<Empresa> Empresa { get; set; }
        [Display(Name = "Vaga")]
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
