using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class Beneficio
    {
        public Beneficio()
        {
            VagaBeneficio = new HashSet<VagaBeneficio>();
        }

        public int Id { get; set; }
        [Display(Name = "Benefício")]
        public string Nome { get; set; } = null!;

        [Display(Name = " Vaga Benefício")]
        public virtual ICollection<VagaBeneficio> VagaBeneficio { get; set; }
    }
}
