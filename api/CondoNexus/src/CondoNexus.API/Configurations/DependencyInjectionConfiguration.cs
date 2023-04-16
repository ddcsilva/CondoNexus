using CondoNexus.Business.Interfaces.Repositories;
using CondoNexus.Data.Repositories;
using CondoNexus.Data.Contexts;
using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Notifications;
using CondoNexus.Business.Interfaces.Services;
using CondoNexus.Business.Services;

namespace CondoNexus.API.Configurations;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<CondoNexusContext>();
        services.AddScoped<ICondominioRepository, CondominioRepository>();
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        services.AddScoped<IMoradorRepository, MoradorRepository>();
        services.AddScoped<IUnidadeRepository, UnidadeRepository>();
        services.AddScoped<IVeiculoRepository, VeiculoRepository>();

        services.AddScoped<ICondominioService, CondominioService>();
        services.AddScoped<IMoradorService, MoradorService>();
        services.AddScoped<IUnidadeService, UnidadeService>();
        services.AddScoped<IVeiculoService, VeiculoService>();

        services.AddScoped<INotificador, Notificador>();

        return services;
    }
}
