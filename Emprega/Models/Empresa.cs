using System;
using System.Collections.Generic;

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
        public string RazaoSocial { get; set; } = null!;
        public string? NomeFantasia { get; set; }
        public string Cnpj { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string? Endereco { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public int? IdCidade { get; set; }
        public ulong OcultarDados { get; set; }
        public string? Site { get; set; }
        public DateOnly DataAbertura { get; set; }
        public int IdAreaAtuacao { get; set; }

        public virtual AreaAtuacao IdAreaAtuacaoNavigation { get; set; } = null!;
        public virtual Cidade? IdCidadeNavigation { get; set; }
        public virtual ICollection<ContatoEmpresa> ContatoEmpresa { get; set; }
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
