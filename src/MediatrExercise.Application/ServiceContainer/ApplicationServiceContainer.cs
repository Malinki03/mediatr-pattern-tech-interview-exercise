using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;
using MediatrExercise.Infrastructure;
using MediatrExercise.Infrastructure.Carts;
using MediatrExercise.Infrastructure.Products;
using MediatrExercise.Infrastructure.ServiceContainer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrExercise.Application.ServiceContainer;

public static class ApplicationServiceContainer
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructureServices(configuration);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceContainer).Assembly);
        });
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IGenericRepository<Cart>, CartPostgresRepository>();
        services.AddTransient<IGenericRepository<Product>, ProductPostgresRepository>();
        return services;
    }
}