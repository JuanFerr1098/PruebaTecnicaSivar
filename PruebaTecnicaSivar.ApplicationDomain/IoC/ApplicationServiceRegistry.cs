using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaSivar.ApplicationDomain.Mapper;
using System.Reflection;

namespace PruebaTecnicaSivar.ApplicationDomain.IoC
{
    public static class ApplicationServiceRegistry
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
