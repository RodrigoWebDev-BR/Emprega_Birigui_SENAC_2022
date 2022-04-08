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
        public string Cnpj { get; set; } = null!;
        public string? Cep { get; set; }
        public string? Endereco { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        [Display(Name = "Cidade")]
        public int? IdCidade { get; set; }
        [Display(Name = "Ocultar Dados")]
        public ulong OcultarDados { get; set; }
        public string? Site { get; set; }
        [Display(Name = "Data de Abertura")]
        public DateOnly DataAbertura { get; set; }
        [Display(Name = "Área de Atuação")]
        public int IdAreaAtuacao { get; set; }

        public virtual AreaAtuacao IdAreaAtuacaoNavigation { get; set; } = null!;
        public virtual Cidade? IdCidadeNavigation { get; set; }
        public virtual ICollection<ContatoEmpresa> ContatoEmpresa { get; set; }
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
