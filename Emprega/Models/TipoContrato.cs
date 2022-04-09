using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class TipoContrato
    {
        public TipoContrato()
        {
            Vaga = new HashSet<Vaga>();
        }

        public int Id { get; set; }
        [Display(Name = "Tipo de Contrato")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Vaga")]
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
