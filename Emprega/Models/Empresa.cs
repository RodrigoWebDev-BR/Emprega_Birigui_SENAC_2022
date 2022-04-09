using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emprega.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            ContatoEmpresa = new HashSet<ContatoEmpresa>();
            Vaga = new HashSet<Vaga>();
        }

        public int Id { get; set; }
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; } = null!;
        [Display(Name = "Nome Fantasia")]
        public string? NomeFantasia { get; set; }
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; } = null!;
        [Display(Name = "CEP")]
        public string? Cep { get; set; }
        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }
        [Display(Name = "Número")]
        public string? Numero { get; set; }
        [Display(Name = "Complemento")]
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        [Display(Name = "Cidade")]
        public int? IdCidade { get; set; }
        [Display(Name = "Ocultar Dados")]
        public ulong OcultarDados { get; set; }
        public string? Site { get; set; }
        [Display(Name = "Data de Abertura")]
        public DateTime DataAbertura { get; set; }
        [Display(Name = "Área de Atuação")]
        public int IdAreaAtuacao { get; set; }

        [Display(Name = "Área Atuação")]
        public virtual AreaAtuacao IdAreaAtuacaoNavigation { get; set; } = null!;
        [Display(Name = "Cidade")]
        public virtual Cidade? IdCidadeNavigation { get; set; }
        [Display(Name = "Contato Empresa")]
        public virtual ICollection<ContatoEmpresa> ContatoEmpresa { get; set; }
        [Display(Name = "Vaga")]
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
