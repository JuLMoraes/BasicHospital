using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfiguration
{
    public class CredencialEntityConfiguration : IEntityTypeConfiguration<Credencial>
    {
        public void Configure(EntityTypeBuilder<Credencial> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FuncionarioId);
            builder.Property(x => x.GrupoAcesso);
            builder.Property(x => x.Login);
            builder.Property(x => x.Senha);
            builder.Property(x => x.Ativo);
        }
    }
}
