using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class ContatoEmpresa
    {
        public int Id { get; set; }
        [Display(Name = "Empresa")]
        public int IdEmpresa { get; set; }
        [Display(Name = "Tipo de Contato")]
        public int IdTipoContato { get; set; }
        [Display(Name = "Contato")]
        public string Contato { get; set; } = null!;

        [Display(Name = "Empresa")]
        public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
        [Display(Name = "Tipo de Contato")]
        public virtual TipoContato IdTipoContatoNavigation { get; set; } = null!;
    }
}
