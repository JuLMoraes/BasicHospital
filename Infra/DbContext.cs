using Domain.Core.Entities;
using Infra.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Infra
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options) 
        {
        }

        public DbConnection Dapper => Database.GetDbConnection();

        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Credencial> Credencial { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConsultaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CredencialEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FuncionarioEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PacienteEntityConfiguration());
        }
    }
}
