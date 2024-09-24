using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.Infrastructure.Adapter;
using PruebaTecnicaSivar.Infrastructure.Context;

namespace PruebaTecnicaSivar.Infrastructure.IoC
{
    public static class InfrastructureServiceRegistry
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InfrastructureEFContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            services.AddScoped<IUserRepository, UserRepositoryAdapter>();
            services.AddScoped<IRoleRepository, RoleRepositoryAdapter>();
            services.AddScoped<ICompanyRepository, CompanyRepositoryAdapter>();
            return services;
        }
    }
}
