using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class InscricaoStatus
    {
        public InscricaoStatus()
        {
            InscricaoVaga = new HashSet<InscricaoVaga>();
        }

        public int Id { get; set; }
        [Display(Name = "Status da Inscrição")]
        public string Nome { get; set; } = null!;
        [Display(Name = "Cor")]
        public string Cor { get; set; } = null!;

        [Display(Name = "Inscrição Vaga")]
        public virtual ICollection<InscricaoVaga> InscricaoVaga { get; set; }
    }
}
