using System;
using System.Collections.Generic;

namespace Emprega.Models
{
    public partial class Vaga
    {
        public Vaga()
        {
            HorarioTrabalho = new HashSet<HorarioTrabalho>();
            InscricaoVaga = new HashSet<InscricaoVaga>();
            VagaBeneficio = new HashSet<VagaBeneficio>();
        }

        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Titulo { get; set; } = null!;
        public decimal? Salario { get; set; }
        public ulong Pcd { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string? Requisitos { get; set; }
        public string? PrincipaisAtividades { get; set; }
        public string? Descricao { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public ulong Situacao { get; set; }
        public string TempoContrato { get; set; } = null!;
        public int IdAreaAtuacao { get; set; }
        public int IdTipoContrato { get; set; }

        public virtual AreaAtuacao IdAreaAtuacaoNavigation { get; set; } = null!;
        public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
        public virtual TipoContrato IdTipoContratoNavigation { get; set; } = null!;
        public virtual ICollection<HorarioTrabalho> HorarioTrabalho { get; set; }
        public virtual ICollection<InscricaoVaga> InscricaoVaga { get; set; }
        public virtual ICollection<VagaBeneficio> VagaBeneficio { get; set; }
    }
}
