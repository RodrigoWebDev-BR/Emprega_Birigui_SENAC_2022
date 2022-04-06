using System;
using System.Collections.Generic;

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
        public string Nome { get; set; } = null!;
        public string Rg { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public int? IdEstadoCivil { get; set; }
        public string? Genero { get; set; }
        public DateTime DataNasc { get; set; }
        public ulong OcultarIdade { get; set; }
        public ulong EstaEmpregado { get; set; }
        public string? Cep { get; set; }
        public string? Endereco { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public int? IdCidade { get; set; }
        public string Senha { get; set; } = null!;
        public int? IdAreaAtuacao { get; set; }
        public int IdNivelEscolaridade { get; set; }
        public string? NotificacaoDevice { get; set; }

        public virtual AreaAtuacao? IdAreaAtuacaoNavigation { get; set; }
        public virtual Cidade? IdCidadeNavigation { get; set; }
        public virtual EstadoCivil? IdEstadoCivilNavigation { get; set; }
        public virtual NivelEscolaridade? IdNivelEscolaridadeNavigation { get; set; } = null!;
        public virtual ICollection<ContatoCandidato> ContatoCandidato { get; set; }
        public virtual ICollection<EducacaoCandidato> EducacaoCandidato { get; set; }
        public virtual ICollection<ExperienciaCandidato> ExperienciaCandidato { get; set; }
        public virtual ICollection<InscricaoVaga> InscricaoVaga { get; set; }
    }
}
