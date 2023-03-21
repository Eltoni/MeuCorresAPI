using DevIO.Business.Intefaces;
using DevIO.Business.Notificacoes;
using DevIO.Business.Services;
using DevIO.Data.Context;
using DevIO.Data.Repository;

namespace DevIO.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IMotoristaRepository, MotoristaRepository>();
            services.AddScoped<ICorridaRepository, CorridaRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoService, VeiculoService>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IMotoristaService, MotoristaService>();
            services.AddScoped<ICorridaService, CorridaService>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUser, AspNetUser>();

            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
