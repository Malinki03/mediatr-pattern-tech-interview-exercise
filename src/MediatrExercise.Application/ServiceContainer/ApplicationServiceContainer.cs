using MediatrExercise.Application.Products.Queries;
using MediatrExercise.Domain.Repositories;
using MediatrExercise.Infrastructure.Carts;
using MediatrExercise.Infrastructure.Products;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrExercise.Application.ServiceContainer;

public static class ApplicationServiceContainer
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceContainer).Assembly);
        });
        services.AddTransient<ICartRepository, CartMemoryRepository>();
        services.AddTransient<IProductRepository, ProductMemoryRepository>();
        return services;
    }
}