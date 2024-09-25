namespace PruebaTecnicaSivar.API.App_Start
{
    internal static class CorsConfig
    {
        internal static IServiceCollection AddCorsDocumentation(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("application/json", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            return services;
        }

        internal static IApplicationBuilder UseCorsDocumentation(this IApplicationBuilder app)
        {
            app.UseCors("SivarPolicy");
            return app;
        }
    }
}
