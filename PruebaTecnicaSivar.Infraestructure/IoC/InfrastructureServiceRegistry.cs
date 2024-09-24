using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.DomainCommon.Repository;
using PruebaTecnicaSivar.Infrastructure.Adapter;
using PruebaTecnicaSivar.Infrastructure.Context;
using PruebaTecnicaSivar.Infrastructure.Mapping;

namespace PruebaTecnicaSivar.Infrastructure.IoC
{
    public static class InfrastructureServiceRegistry
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(InfrastructureMappingProfile));

            services.AddDbContext<InfrastructureEFContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddScoped<IBaseRepositoryFactory, BaseRepositoryFactoryAdapter>();
            services.AddScoped<IUserRepository, UserRepositoryAdapter>();
            services.AddScoped<IRoleRepository, RoleRepositoryAdapter>();
            services.AddScoped<ICompanyRepository, CompanyRepositoryAdapter>();
            return services;
        }
    }
}
