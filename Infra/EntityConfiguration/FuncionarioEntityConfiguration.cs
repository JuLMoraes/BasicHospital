using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfiguration
{
    public class FuncionarioEntityConfiguration : EntityTypeConfigurationAttribute<FuncionarioEntity>
    {
        //public EntityTypeConfigurationAttribute Configure(EntityTypeBuilder builder)
        //{
        //    builder.HasKey(FuncionarioEntity.Id)
        //}
    }
}
