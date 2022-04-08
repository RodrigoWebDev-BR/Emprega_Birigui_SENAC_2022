using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class VagaBeneficio
    {
        public int Id { get; set; }
        [Display(Name = "Vaga")]
        public int IdVaga { get; set; }
        [Display(Name = "Benefício")]
        public int IdBeneficio { get; set; }
        public int IdVaga { get; set; }

        [Display(Name = "Benefício")]
        public virtual Beneficio IdBeneficioNavigation { get; set; } = null!;
        [Display(Name = "Vaga")]
        public virtual Vaga IdVagaNavigation { get; set; } = null!;
    }
}
