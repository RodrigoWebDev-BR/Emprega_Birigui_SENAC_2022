using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class Candidato
    {
        public Candidato()
        {
            ContatoCandidato = new HashSet<ContatoCandidato>();
            EducacaoCandidato = new HashSet<EducacaoCandidato>();
            ExperienciaCandidato = new HashSet<ExperienciaCandidato>();
            InscricaoVaga = new HashSet<InscricaoVaga>();
        }

        public int Id { get; set; }
        [Display(Name = "Candidato")]
        public string Nome { get; set; } = null!;
        [Display(Name = "RG")]
        public string Rg { get; set; } = null!;
        [Display(Name = "CPF")]
        public string Cpf { get; set; } = null!;
        [Display(Name = "Estado Civil")]
        public int? IdEstadoCivil { get; set; }
        [Display(Name = "Gênero")]
        public string? Genero { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }
        [Display(Name = "Ocultar Idade?")]
        public ulong OcultarIdade { get; set; }
        [Display(Name = "Está Empregado?")]
        public ulong EstaEmpregado { get; set; }
        [Display(Name = "CEP")]
        public string? Cep { get; set; }
        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }
        [Display(Name = "Número")]
        public string? Numero { get; set; }
        [Display(Name = "Complemento")]
        public string? Complemento { get; set; }
        [Display(Name = "Bairro")]
        public string? Bairro { get; set; }
        [Display(Name = "Cidade")]
        public int? IdCidade { get; set; }
        [Display(Name = "Senha")]
        public string Senha { get; set; } = null!;
        [Display(Name = "Área de Atuação")]
        public int? IdAreaAtuacao { get; set; }
        [Display(Name = "Nível de Escolaridade")]
        public int IdNivelEscolaridade { get; set; }
        [Display(Name = "Receber Notificações?")]
        public string? NotificacaoDevice { get; set; }

        [Display(Name = "Área Atuação")]
        public virtual AreaAtuacao? IdAreaAtuacaoNavigation { get; set; }
        [Display(Name = "Cidade")]
        public virtual Cidade? IdCidadeNavigation { get; set; }
        [Display(Name = "Estado Civil")]
        public virtual EstadoCivil? IdEstadoCivilNavigation { get; set; }
        [Display(Name = "Nível Escolaridade")]
        public virtual NivelEscolaridade IdNivelEscolaridadeNavigation { get; set; } = null!;
        [Display(Name = "Contato Candidato")]
        public virtual ICollection<ContatoCandidato> ContatoCandidato { get; set; }
        [Display(Name = "Educação Candidato")]
        public virtual ICollection<EducacaoCandidato> EducacaoCandidato { get; set; }
        [Display(Name = "Experiência Candidato")]
        public virtual ICollection<ExperienciaCandidato> ExperienciaCandidato { get; set; }
        [Display(Name = "Inscrição Vaga")]
        public virtual ICollection<InscricaoVaga> InscricaoVaga { get; set; }
    }
}
