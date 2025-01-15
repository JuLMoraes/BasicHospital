using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfiguration
{
    public class PacienteEntityConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome);
            builder.Property(x => x.Nascimento);
            builder.Property(x => x.TipoSanguineo);
            builder.Property(x => x.Sexo);
            builder.Property(x => x.PlanoSaude);
            builder.Property(x => x.TelefoneCelular);
            builder.Property(x => x.Email);
            builder.Property(x => x.Logradouro);
            builder.Property(x => x.Numero);
            builder.Property(x => x.Complemento);
            builder.Property(x => x.Cidade);
            builder.Property(x => x.Estado);
            builder.Property(x => x.CEP);
            builder.Property(x => x.Cadastro);
            builder.Property(x => x.Modificacao);
            builder.Property(x => x.Ativo);
        }
    }
}
