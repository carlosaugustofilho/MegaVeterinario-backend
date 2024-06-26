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

        //public DbSet<UsuarioResponse> Usuarios { get; set; }
        public DbSet<ClienteResponse> Clientes { get; set; }
        //public DbSet<FuncionarioResponse> Funcionarios { get; set; }
        //public DbSet<VeterinarioResponse> Veterinarios { get; set; }
        //public DbSet<AnimalResponse> Animais { get; set; }
        //public DbSet<ClinicaResponse> Clinicas { get; set; }
        //public DbSet<ConsultaResponse> Consultas { get; set; }
        //public DbSet<TratamentoResponse> Tratamentos { get; set; }
        //public DbSet<MedicamentoResponse> Medicamentos { get; set; }
        //public DbSet<TratamentoMedicamentoResponse> TratamentosMedicamentos { get; set; }
        //public DbSet<ExameResponse> Exames { get; set; }
        //public DbSet<ProcedimentoResponse> Procedimentos { get; set; }
        //public DbSet<FornecedorResponse> Fornecedores { get; set; }
        //public DbSet<EstoqueResponse> Estoques { get; set; }
        //public DbSet<MetodoPagamentoResponse> MetodosPagamento { get; set; }
        //public DbSet<PagamentoResponse> Pagamentos { get; set; }
        //public DbSet<AgendamentoResponse> Agendamentos { get; set; }
        //public DbSet<NotificacaoResponse> Notificacoes { get; set; }
        //public DbSet<ProgramaFidelidadeResponse> ProgramasFidelidade { get; set; }
        //public DbSet<HistoricoAlteracaoResponse> HistoricoAlteracoes { get; set; }
        //public DbSet<RelatorioResponse> Relatorios { get; set; }
        //public DbSet<PlanoResponse> Planos { get; set; }
        //public DbSet<VendaPlanoResponse> VendasPlanos { get; set; }
        //public DbSet<LogAtividadeResponse> LogsAtividades { get; set; }
        public DbSet<EnderecoResponse> Enderecos { get; set; }

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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClienteResponse>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Telefone).IsRequired();
                entity.Property(e => e.DataNascimento).IsRequired();
                entity.Property(e => e.CPF).IsRequired();
                entity.Property(e => e.Email).IsRequired();

                entity.HasOne(e => e.Endereco)
                      .WithOne()
                      .HasForeignKey<ClienteResponse>(e => e.Endereco.Id);
            });

            modelBuilder.Entity<EnderecoResponse>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Cep).IsRequired();
                entity.Property(e => e.Rua).IsRequired();
                entity.Property(e => e.Numero).IsRequired();
                entity.Property(e => e.Complemento).IsRequired(false);
                entity.Property(e => e.Bairro).IsRequired();
                entity.Property(e => e.Cidade).IsRequired();
                entity.Property(e => e.Estado).IsRequired();
                entity.Property(e => e.PaisId).IsRequired();
            });
        }
    }
}
