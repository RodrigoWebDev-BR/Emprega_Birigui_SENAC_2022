using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Empresa")]
        public int IdEmpresa { get; set; }
        [Display(Name = "Título")]
        public string Titulo { get; set; } = null!;
        [Display(Name = "Salário")]
        public decimal? Salario { get; set; }
        [Display(Name = "PCD")]
        public ulong Pcd { get; set; }
        [Display(Name = "Data de publicação")]
        public DateTime? DataPublicacao { get; set; }
        public string? Requisitos { get; set; }
        [Display(Name = "Principais atividades")]
        public string? PrincipaisAtividades { get; set; }
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
        public int Quantidade { get; set; }
        [Display(Name = "Quantidade disponível")]
        public int QuantidadeDisponivel { get; set; }
        [Display(Name = "Situação")]
        public ulong Situacao { get; set; }
        [Display(Name = "Tempo de contrato")]
        public string TempoContrato { get; set; } = null!;
        [Display(Name = "Área de atuação")]
        public int IdAreaAtuacao { get; set; }
        [Display(Name = "Tipo de contrato")]
        public int IdTipoContrato { get; set; }

        [Display(Name = "Área de atuação")]
        public virtual AreaAtuacao? IdAreaAtuacaoNavigation { get; set; }
        [Display(Name = "Empresa")]
        public virtual Empresa? IdEmpresaNavigation { get; set; }
        [Display(Name = "Tipo de contrato")]
        public virtual TipoContrato? IdTipoContratoNavigation { get; set; } 
        public virtual ICollection<HorarioTrabalho> HorarioTrabalho { get; set; }
        public virtual ICollection<InscricaoVaga> InscricaoVaga { get; set; }
        public virtual ICollection<VagaBeneficio> VagaBeneficio { get; set; }
    }
}
