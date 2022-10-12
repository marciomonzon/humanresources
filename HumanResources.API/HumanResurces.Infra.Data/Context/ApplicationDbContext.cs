using HumanResources.Domain.Entities;
using HumanResurces.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace HumanResurces.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CargoFuncaoConfiguration());
            modelBuilder.ApplyConfiguration(new ColaboradorConfiguration());
            modelBuilder.ApplyConfiguration(new ContratroConfiguration());
        }

        public DbSet<CargoFuncao> CargoFuncao { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
    }
}
