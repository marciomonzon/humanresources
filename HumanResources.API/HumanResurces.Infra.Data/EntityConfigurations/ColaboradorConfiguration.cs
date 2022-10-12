using HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResurces.Infra.Data.EntityConfigurations
{
    public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.DataDeNascimento).IsRequired();
            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("varchar");
            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("varchar");

            builder.HasOne(colaborador => colaborador.Contrato)
                   .WithMany(contrato => contrato.Colaboradores)
                   .HasForeignKey(colaborador => colaborador.ContratoId);

            builder.HasOne(colaborador => colaborador.CargoFuncao)
                    .WithMany(cargoFuncao => cargoFuncao.Colaboradores)
                    .HasForeignKey(colaborador => colaborador.CargoFuncaoId);
        }
    }
}
