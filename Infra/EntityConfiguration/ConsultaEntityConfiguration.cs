using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfiguration
{
    public class ConsultaEntityConfiguration : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PacienteId);
            builder.Property(x => x.FuncionarioId);
            builder.Property(x => x.Data);
            builder.Property(x => x.Descricao);
            builder.Property(x => x.Cadastro);
            builder.Property(x => x.Modificacao);
            builder.Property(x => x.Ativo);
        }
    }
}
