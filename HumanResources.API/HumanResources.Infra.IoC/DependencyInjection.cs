using HumanResources.Domain.Interfaces.Repositories;
using HumanResurces.Infra.Data.Context;
using HumanResurces.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResources.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext)
                              .Assembly.FullName)));

            services.AddScoped<ICargoFuncaoRepository, CargoFuncaoRepository>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IContratoRepository, ContratoRepository>();
            services.AddScoped<IUnitOfWork, UnityOfWork>();

            return services;
        }
    }
}
