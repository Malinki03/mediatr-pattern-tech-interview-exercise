using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrExercise.Infrastructure.ServiceContainer;

public static class InfrastructureServiceContainer
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseLazyLoadingProxies();
            options.UseNpgsql(configuration.GetConnectionString("PostgresDatabase"));
            options.UseSnakeCaseNamingConvention();
        });
        return services;
    }
}