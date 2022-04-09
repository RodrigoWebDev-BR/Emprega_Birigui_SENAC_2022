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
        [Display(Name = "T´tulo da Vaga")]
        public string Titulo { get; set; } = null!;
        [Display(Name = "Salário")]
        public decimal? Salario { get; set; }
        [Display(Name = "PCD")]
        public ulong Pcd { get; set; }
        [Display(Name = "Data de Publicação")]
        public DateTime? DataPublicacao { get; set; }
        [Display(Name = "Requisitos")]
        public string? Requisitos { get; set; }
        [Display(Name = "Principais Atividades")]
        public string? PrincipaisAtividades { get; set; }
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }
        [Display(Name = "Quantidade Disponível")]
        public int QuantidadeDisponivel { get; set; }
        [Display(Name = "Situação")]
        public ulong Situacao { get; set; }
        [Display(Name = "Tempo de Contrato")]
        public string TempoContrato { get; set; } = null!;
        [Display(Name = "Área de Atuação")]
        public int IdAreaAtuacao { get; set; }
        [Display(Name = "Tipo de Contrato")]
        public int IdTipoContrato { get; set; }

        [Display(Name = "Área de Atuação")]
        public virtual AreaAtuacao IdAreaAtuacaoNavigation { get; set; } = null!;
        [Display(Name = "Empresa")]
        public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
        [Display(Name = "Tipo de Contrato")]
        public virtual TipoContrato IdTipoContratoNavigation { get; set; } = null!;
        [Display(Name = "Horário de Trabalho")]
        public virtual ICollection<HorarioTrabalho> HorarioTrabalho { get; set; }
        [Display(Name = "Inscrição Vaga")]
        public virtual ICollection<InscricaoVaga> InscricaoVaga { get; set; }
        [Display(Name = "Vaga Benefício")]
        public virtual ICollection<VagaBeneficio> VagaBeneficio { get; set; }
    }
}
