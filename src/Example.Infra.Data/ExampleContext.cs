using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Example.Infra.Data
{
    /// <summary>
    /// Referência de artigo para conseguir criar modelos de configuração
    /// https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
    /// Rererência de artigo para conseguir criar migration a partir de dominios
    /// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
    /// </summary>
    public class ExampleContext : DbContext
    {
        public DbSet<Domain.CidadeAggregate.Cidade> Cidade { get; set; }
        public DbSet<Domain.PessoaAggregate.Pessoa> Pessoa { get; set; }
        public ExampleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CidadeEntityTypeConfiguration());
            modelBuilder.Entity<Domain.CidadeAggregate.Cidade>();
            
            modelBuilder.ApplyConfiguration(new PessoaEntityTypeConfiguration());
            modelBuilder.Entity<Domain.PessoaAggregate.Pessoa>();

        }
    }

    public class PessoaEntityTypeConfiguration : IEntityTypeConfiguration<Domain.PessoaAggregate.Pessoa>
    {
        public void Configure(EntityTypeBuilder<Domain.PessoaAggregate.Pessoa> orderConfiguration)
        {
            orderConfiguration.ToTable("Pessoa", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Nome).IsRequired();
            orderConfiguration.Property(o => o.Cpf).IsRequired();
            orderConfiguration.HasOne(o => o.Cidade)
                .WithMany(c => c.Pessoas)
                .HasForeignKey(o => o.Id_Cidade)
                .HasConstraintName("FK_Cidade")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            orderConfiguration.Property(o => o.Idade).IsRequired();
        }
    }

        public class CidadeEntityTypeConfiguration : IEntityTypeConfiguration<Domain.CidadeAggregate.Cidade>
    {
        public void Configure(EntityTypeBuilder<Domain.CidadeAggregate.Cidade> orderConfiguration)
        {
            orderConfiguration.ToTable("Cidade", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Nome).IsRequired();
            orderConfiguration.Property(o => o.Uf).IsRequired();
        }
    }
}
