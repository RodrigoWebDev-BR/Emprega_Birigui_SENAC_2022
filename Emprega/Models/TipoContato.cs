using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class TipoContato
    {
        public TipoContato()
        {
            ContatoCandidato = new HashSet<ContatoCandidato>();
            ContatoEmpresa = new HashSet<ContatoEmpresa>();
        }

        public int Id { get; set; }
        [Display(Name = "Tipo de Contato")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Contato do Candidato")]
        public virtual ICollection<ContatoCandidato> ContatoCandidato { get; set; }
        [Display(Name = "Contato da Empresa")]
        public virtual ICollection<ContatoEmpresa> ContatoEmpresa { get; set; }
    }
}
