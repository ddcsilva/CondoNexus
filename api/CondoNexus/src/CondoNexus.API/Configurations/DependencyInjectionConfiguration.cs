using CondoNexus.Business.Interfaces.Repositories;
using CondoNexus.Data.Repositories;
using CondoNexus.Data.Contexts;

namespace CondoNexus.API.Configurations;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<CondoNexusContext>();
        services.AddScoped<ICondominioRepository, CondominioRepository>();

        return services;
    }
}
