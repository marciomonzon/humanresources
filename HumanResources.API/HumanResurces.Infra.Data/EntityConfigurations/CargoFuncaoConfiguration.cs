using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResurces.Infra.Data.EntityConfigurations
{
    public class CargoFuncaoConfiguration : IEntityTypeConfiguration<CargoFuncao>
    {
        public void Configure(EntityTypeBuilder<CargoFuncao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.NomeCargo)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("varchar");
            builder.Property(x => x.Funcao)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("varchar");
        }
    }
}
