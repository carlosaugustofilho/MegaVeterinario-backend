using Microsoft.EntityFrameworkCore;
using MegaVetClinic.Repository.Models.Response;

namespace MegaVetClinic.Core.Context
{
    public class MegaVetClinicContext : DbContext
    {
        private readonly string strConexao = "Server=localhost;Database=mega_vet_clinic_db;Uid=root;Password=root;SSL Mode=None";

        public MegaVetClinicContext(DbContextOptions<MegaVetClinicContext> options)
            : base(options)
        {
        }

        public DbSet<ClienteResponse> Clientes { get; set; }
        public DbSet<EnderecoResponse> Enderecos { get; set; }
        public DbSet<UsuarioResponse> Usuarios { get; set; }

        // Método para execução de comandos SQL
        public void Execute(string sqlCommand)
        {
            Database.ExecuteSqlRaw(sqlCommand);
        }

        public List<T> Execute<T>(string sqlCommand) where T : class
        {
            return Set<T>().FromSqlRaw(sqlCommand).ToList();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteResponse>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<EnderecoResponse>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<UsuarioResponse>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<ClienteResponse>()
                .HasOne(c => c.Endereco)
                .WithOne(e => e.Cliente)
                .HasForeignKey<EnderecoResponse>(e => e.Id) // Definindo a chave estrangeira correta
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EnderecoResponse>()
                .HasOne(e => e.Cliente)
                .WithOne(c => c.Endereco)
                .HasForeignKey<ClienteResponse>(c => c.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ClienteResponse>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
