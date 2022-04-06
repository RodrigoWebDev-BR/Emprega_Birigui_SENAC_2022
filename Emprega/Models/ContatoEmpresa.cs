using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class ContatoEmpresa
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int IdTipoContato { get; set; }
        public string Contato { get; set; } = null!;

        public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
        public virtual TipoContato IdTipoContatoNavigation { get; set; } = null!;
    }
}
