using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Emprega.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AreaAtuacao> AreaAtuacao { get; set; } = null!;
        public virtual DbSet<Beneficio> Beneficio { get; set; } = null!;
        public virtual DbSet<Candidato> Candidato { get; set; } = null!;
        public virtual DbSet<Cidade> Cidade { get; set; } = null!;
        public virtual DbSet<ContatoCandidato> ContatoCandidato { get; set; } = null!;
        public virtual DbSet<ContatoEmpresa> ContatoEmpresa { get; set; } = null!;
        public virtual DbSet<EducacaoCandidato> EducacaoCandidato { get; set; } = null!;
        public virtual DbSet<Empresa> Empresa { get; set; } = null!;
        public virtual DbSet<EstadoCivil> EstadoCivil { get; set; } = null!;
        public virtual DbSet<ExperienciaCandidato> ExperienciaCandidato { get; set; } = null!;
        public virtual DbSet<HorarioTrabalho> HorarioTrabalho { get; set; } = null!;
        public virtual DbSet<Idioma> Idioma { get; set; } = null!;
        public virtual DbSet<IdiomaCandidato> IdiomaCandidato { get; set; } = null!;
        public virtual DbSet<InscricaoStatus> InscricaoStatus { get; set; } = null!;
        public virtual DbSet<InscricaoVaga> InscricaoVaga { get; set; } = null!;
        public virtual DbSet<NivelEscolaridade> NivelEscolaridade { get; set; } = null!;
        public virtual DbSet<TipoContato> TipoContato { get; set; } = null!;
        public virtual DbSet<TipoContrato> TipoContrato { get; set; } = null!;
        public virtual DbSet<Vaga> Vaga { get; set; } = null!;
        public virtual DbSet<VagaBeneficio> VagaBeneficio { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=Senac123;database=emprega_birigui", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.5-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<AreaAtuacao>(entity =>
            {
                entity.ToTable("area_atuacao");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Beneficio>(entity =>
            {
                entity.ToTable("beneficio");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.ToTable("candidato");

                entity.HasIndex(e => e.IdAreaAtuacao, "FK_candidato_area_atuacao");

                entity.HasIndex(e => e.IdCidade, "FK_candidato_cidade");

                entity.HasIndex(e => e.IdEstadoCivil, "FK_candidato_estado_civil");

                entity.HasIndex(e => e.IdNivelEscolaridade, "FK_candidato_nivel_escolaridade");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(150)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cep)
                    .HasMaxLength(9)
                    .HasColumnName("cep")
                    .IsFixedLength();

                entity.Property(e => e.Complemento)
                    .HasMaxLength(20)
                    .HasColumnName("complemento");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(14)
                    .HasColumnName("cpf")
                    .IsFixedLength();

                entity.Property(e => e.DataNasc).HasColumnName("data_nasc");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(150)
                    .HasColumnName("endereco");

                entity.Property(e => e.EstaEmpregado)
                    .HasColumnType("bit(1)")
                    .HasColumnName("esta_empregado")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Genero)
                    .HasMaxLength(1)
                    .HasColumnName("genero")
                    .IsFixedLength();

                entity.Property(e => e.IdAreaAtuacao)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_area_atuacao");

                entity.Property(e => e.IdCidade)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_cidade");

                entity.Property(e => e.IdEstadoCivil)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_estado_civil");

                entity.Property(e => e.IdNivelEscolaridade)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_nivel_escolaridade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.NotificacaoDevice)
                    .HasMaxLength(255)
                    .HasColumnName("notificacao_device")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .HasColumnName("numero");

                entity.Property(e => e.OcultarIdade)
                    .HasColumnType("bit(1)")
                    .HasColumnName("ocultar_idade")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Rg)
                    .HasMaxLength(11)
                    .HasColumnName("rg");

                entity.Property(e => e.Senha)
                    .HasMaxLength(255)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdAreaAtuacaoNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdAreaAtuacao)
                    .HasConstraintName("FK_candidato_area_atuacao");

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdCidade)
                    .HasConstraintName("FK_candidato_cidade");

                entity.HasOne(d => d.IdEstadoCivilNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdEstadoCivil)
                    .HasConstraintName("FK_candidato_estado_civil");

                entity.HasOne(d => d.IdNivelEscolaridadeNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdNivelEscolaridade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_candidato_nivel_escolaridade");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.ToTable("cidade");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(120)
                    .HasColumnName("nome");

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .HasColumnName("uf")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ContatoCandidato>(entity =>
            {
                entity.ToTable("contato_candidato");

                entity.HasIndex(e => e.IdCandidato, "FK_candidato");

                entity.HasIndex(e => e.IdTipoContato, "FK_tipo_contato");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Contato)
                    .HasMaxLength(255)
                    .HasColumnName("contato");

                entity.Property(e => e.IdCandidato)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_candidato");

                entity.Property(e => e.IdTipoContato)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_tipo_contato");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.ContatoCandidato)
                    .HasForeignKey(d => d.IdCandidato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_candidato");

                entity.HasOne(d => d.IdTipoContatoNavigation)
                    .WithMany(p => p.ContatoCandidato)
                    .HasForeignKey(d => d.IdTipoContato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipo_contato");
            });

            modelBuilder.Entity<ContatoEmpresa>(entity =>
            {
                entity.ToTable("contato_empresa");

                entity.HasIndex(e => e.IdEmpresa, "FK_contato_empresa");

                entity.HasIndex(e => e.IdTipoContato, "FK_empresa_tipo_contato");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Contato)
                    .HasMaxLength(255)
                    .HasColumnName("contato");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_empresa");

                entity.Property(e => e.IdTipoContato)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_tipo_contato");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.ContatoEmpresa)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_contato_empresa");

                entity.HasOne(d => d.IdTipoContatoNavigation)
                    .WithMany(p => p.ContatoEmpresa)
                    .HasForeignKey(d => d.IdTipoContato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empresa_tipo_contato");
            });

            modelBuilder.Entity<EducacaoCandidato>(entity =>
            {
                entity.ToTable("educacao_candidato");

                entity.HasIndex(e => e.IdCandidato, "FK_id_candidato2");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Curso)
                    .HasMaxLength(100)
                    .HasColumnName("curso");

                entity.Property(e => e.Fim).HasColumnName("fim");

                entity.Property(e => e.IdCandidato)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_candidato");

                entity.Property(e => e.Inicio).HasColumnName("inicio");

                entity.Property(e => e.Instituicao)
                    .HasMaxLength(150)
                    .HasColumnName("instituicao");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.EducacaoCandidato)
                    .HasForeignKey(d => d.IdCandidato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_candidato2");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("empresa");

                entity.HasIndex(e => e.IdAreaAtuacao, "FK_empresa_area_atuacao");

                entity.HasIndex(e => e.IdCidade, "FK_empresa_cidade");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(150)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cep)
                    .HasMaxLength(9)
                    .HasColumnName("cep")
                    .IsFixedLength();

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(18)
                    .HasColumnName("cnpj")
                    .IsFixedLength();

                entity.Property(e => e.Complemento)
                    .HasMaxLength(20)
                    .HasColumnName("complemento");

                entity.Property(e => e.DataAbertura).HasColumnName("data_abertura");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(150)
                    .HasColumnName("endereco");

                entity.Property(e => e.IdAreaAtuacao)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_area_atuacao");

                entity.Property(e => e.IdCidade)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_cidade");

                entity.Property(e => e.NomeFantasia)
                    .HasMaxLength(100)
                    .HasColumnName("nome_fantasia");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .HasColumnName("numero");

                entity.Property(e => e.OcultarDados)
                    .HasColumnType("bit(1)")
                    .HasColumnName("ocultar_dados");

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(150)
                    .HasColumnName("razao_social");

                entity.Property(e => e.Site)
                    .HasMaxLength(100)
                    .HasColumnName("site");

                entity.HasOne(d => d.IdAreaAtuacaoNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdAreaAtuacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empresa_area_atuacao");

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdCidade)
                    .HasConstraintName("FK_empresa_cidade");
            });

            modelBuilder.Entity<EstadoCivil>(entity =>
            {
                entity.ToTable("estado_civil");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<ExperienciaCandidato>(entity =>
            {
                entity.ToTable("experiencia_candidato");

                entity.HasIndex(e => e.IdCandidato, "FK_id_candidato");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Admissao).HasColumnName("admissao");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(100)
                    .HasColumnName("cargo");

                entity.Property(e => e.Demissao).HasColumnName("demissao");

                entity.Property(e => e.Descricao)
                    .HasColumnType("text")
                    .HasColumnName("descricao");

                entity.Property(e => e.Empresa)
                    .HasMaxLength(150)
                    .HasColumnName("empresa");

                entity.Property(e => e.IdCandidato)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_candidato");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.ExperienciaCandidato)
                    .HasForeignKey(d => d.IdCandidato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_candidato");
            });

            modelBuilder.Entity<HorarioTrabalho>(entity =>
            {
                entity.ToTable("horario_trabalho");

                entity.HasIndex(e => e.IdVaga, "FK_horario_vaga");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DiaSemana)
                    .HasMaxLength(20)
                    .HasColumnName("dia_semana");

                entity.Property(e => e.HorarioFinal)
                    .HasColumnType("time")
                    .HasColumnName("horario_final");

                entity.Property(e => e.HorarioInicial)
                    .HasColumnType("time")
                    .HasColumnName("horario_inicial");

                entity.Property(e => e.IdVaga)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_vaga");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.HorarioTrabalho)
                    .HasForeignKey(d => d.IdVaga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_horario_vaga");
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.ToTable("idioma");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<IdiomaCandidato>(entity =>
            {
                entity.ToTable("idioma_candidato");

                entity.HasIndex(e => e.IdIdioma, "FK_id_idioma");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdIdioma)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_idioma");

                entity.Property(e => e.Nivel)
                    .HasMaxLength(20)
                    .HasColumnName("nivel");

                entity.HasOne(d => d.IdIdiomaNavigation)
                    .WithMany(p => p.IdiomaCandidato)
                    .HasForeignKey(d => d.IdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_idioma");
            });

            modelBuilder.Entity<InscricaoStatus>(entity =>
            {
                entity.ToTable("inscricao_status");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cor)
                    .HasMaxLength(7)
                    .HasColumnName("cor")
                    .IsFixedLength();

                entity.Property(e => e.Nome)
                    .HasMaxLength(40)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<InscricaoVaga>(entity =>
            {
                entity.ToTable("inscricao_vaga");

                entity.HasIndex(e => e.IdCandidato, "FK_inscricao_candidato");

                entity.HasIndex(e => e.IdStatus, "FK_inscricao_status");

                entity.HasIndex(e => e.IdVaga, "FK_inscricao_vaga");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.IdCandidato)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_candidato");

                entity.Property(e => e.IdStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_status");

                entity.Property(e => e.IdVaga)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_vaga");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.InscricaoVaga)
                    .HasForeignKey(d => d.IdCandidato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_inscricao_candidato");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.InscricaoVaga)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_inscricao_status");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.InscricaoVaga)
                    .HasForeignKey(d => d.IdVaga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_inscricao_vaga");
            });

            modelBuilder.Entity<NivelEscolaridade>(entity =>
            {
                entity.ToTable("nivel_escolaridade");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TipoContato>(entity =>
            {
                entity.ToTable("tipo_contato");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(25)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TipoContrato>(entity =>
            {
                entity.ToTable("tipo_contrato");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.ToTable("vaga");

                entity.HasIndex(e => e.IdAreaAtuacao, "FK_vaga_area_atuacao");

                entity.HasIndex(e => e.IdEmpresa, "FK_vaga_empresa");

                entity.HasIndex(e => e.IdTipoContrato, "FK_vaga_tipo_contrato");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DataPublicacao)
                    .HasColumnType("datetime")
                    .HasColumnName("data_publicacao");

                entity.Property(e => e.Descricao)
                    .HasColumnType("text")
                    .HasColumnName("descricao");

                entity.Property(e => e.IdAreaAtuacao)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_area_atuacao");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_empresa");

                entity.Property(e => e.IdTipoContrato)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_tipo_contrato");

                entity.Property(e => e.Pcd)
                    .HasColumnType("bit(1)")
                    .HasColumnName("pcd");

                entity.Property(e => e.PrincipaisAtividades)
                    .HasColumnType("text")
                    .HasColumnName("principais_atividades");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantidade");

                entity.Property(e => e.QuantidadeDisponivel)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantidade_disponivel");

                entity.Property(e => e.Requisitos)
                    .HasColumnType("text")
                    .HasColumnName("requisitos");

                entity.Property(e => e.Salario)
                    .HasPrecision(10, 2)
                    .HasColumnName("salario");

                entity.Property(e => e.Situacao)
                    .HasColumnType("bit(1)")
                    .HasColumnName("situacao");

                entity.Property(e => e.TempoContrato)
                    .HasMaxLength(20)
                    .HasColumnName("tempo_contrato")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(30)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdAreaAtuacaoNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdAreaAtuacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vaga_area_atuacao");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vaga_empresa");

                entity.HasOne(d => d.IdTipoContratoNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdTipoContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vaga_tipo_contrato");
            });

            modelBuilder.Entity<VagaBeneficio>(entity =>
            {
                entity.ToTable("vaga_beneficio");

                entity.HasIndex(e => e.IdBeneficio, "FK_beneficio_vaga");

                entity.HasIndex(e => e.IdVaga, "FK_vaga_beneficio");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdBeneficio)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_beneficio");

                entity.Property(e => e.IdVaga)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_vaga");

                entity.HasOne(d => d.IdBeneficioNavigation)
                    .WithMany(p => p.VagaBeneficio)
                    .HasForeignKey(d => d.IdBeneficio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_beneficio_vaga");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.VagaBeneficio)
                    .HasForeignKey(d => d.IdVaga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vaga_beneficio");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
