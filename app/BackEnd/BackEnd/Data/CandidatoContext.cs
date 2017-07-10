using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BackEnd.Data
{
    public class CandidatoContext : DbContext
    {
        public DbSet<Candidato> Candidatos { get; set; }

        public CandidatoContext()
        {
        }

        public CandidatoContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidato>()
                .ToTable("Candidato");

            modelBuilder.Entity<Candidato>()
                .Property(s => s.Nome)
                .IsRequired();

            modelBuilder.Entity<Candidato>()
                .Property(s => s.Email)
                .IsRequired();

            modelBuilder.Entity<Candidato>()
                .Property(s => s.Skype)
                .IsRequired();

            modelBuilder.Entity<Candidato>()
                .Property(s => s.Telefone)
                .IsRequired();

            modelBuilder.Entity<Candidato>()
                .Property(s => s.Linkedin)
                .IsRequired();

            modelBuilder.Entity<Candidato>()
                .Property(s => s.Cidade)
                .IsRequired();

            modelBuilder.Entity<Candidato>()
                .Property(s => s.Estado)
                .IsRequired();

            modelBuilder.Entity<Candidato>()
                .Property(s => s.Portfolio)
                .IsRequired();

            modelBuilder.Entity<Candidato>()
                .Property(s => s.Disponibilidade)
                .IsRequired();

            modelBuilder.Entity<Candidato>()
                .Property(s => s.HorarioDeTrabalho)
                .IsRequired();

            modelBuilder.Entity<Candidato>()
                .Property(s => s.PretensaoSalarial)
                .IsRequired();

            modelBuilder.Entity<Candidato>()
                .Property(s => s.InformacoesBanco)
                .IsRequired();

            modelBuilder.Entity<Candidato>()
                .Property(s => s.LinkCrud)
                .IsRequired();

            modelBuilder.Entity<Candidato>()
                .HasOne(s => s.ContaBancaria)
                .WithOne(x => x.Candidato)
                .HasForeignKey<Candidato>(s => s.IdContaBancaria)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ContaBancaria>()
                .Property(s => s.Cnpj)
                .IsRequired();

            modelBuilder.Entity<ContaBancaria>()
                .Property(s => s.Nome)
                .IsRequired();

            modelBuilder.Entity<ContaBancaria>()
                .Property(s => s.Banco)
                .IsRequired();

            modelBuilder.Entity<ContaBancaria>()
                .Property(s => s.Agencia)
                .IsRequired();

            modelBuilder.Entity<ContaBancaria>()
                .Property(s => s.Tipo)
                .IsRequired();

            modelBuilder.Entity<ContaBancaria>()
                .Property(s => s.Numero)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = ObterConfiguracoes();

            optionsBuilder.UseSqlServer(configuration["Data:ConnectionString"]);

            base.OnConfiguring(optionsBuilder);
        }

        private static IConfigurationRoot ObterConfiguracoes()
        {
            var builder = new ConfigurationBuilder();

            var caminhoBase = Path.Combine("..", "..", Directory.GetCurrentDirectory());
            builder.SetBasePath(caminhoBase);
            builder.AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
