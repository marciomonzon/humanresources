using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResurces.Infra.Data.EntityConfigurations
{
    public class ContratroConfiguration : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.TipoContrato)
                   .IsRequired()
                   .HasMaxLength(2)
                   .HasColumnType("varchar");
        }
    }
}
