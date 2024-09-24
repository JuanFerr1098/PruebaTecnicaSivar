using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaSivar.ApplicationDomain.Behaviours;
using PruebaTecnicaSivar.ApplicationDomain.Mapper;
using System.Reflection;

namespace PruebaTecnicaSivar.ApplicationDomain.IoC
{
    public static class ApplicationServiceRegistry
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
