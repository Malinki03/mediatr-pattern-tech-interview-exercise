using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;

namespace MediatrExercise.Infrastructure;

public class UnitOfWork(DataContext dataContext,
    IGenericRepository<Product> productRepository,
    IGenericRepository<Cart> cartRepository,
    ILogger<UnitOfWork> logger) : IUnitOfWork
{
    public IGenericRepository<Cart> cartRepository { get; init; } = cartRepository;
    public IGenericRepository<Product> productRepository { get; init; } = productRepository;

    public async Task ExecuteInUnitOfWorkAsync(Func<Task> action, CancellationToken cancellationToken = default)
    {
        try
        {
            await action();
            await SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Exception while running unit of work, no changes have been made");
            throw;
        }
    }
    public async Task<T> ExecuteInUnitOfWorkAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await action();
            await SaveChangesAsync(cancellationToken);
            return result;
        }
        catch (Exception e)
        {
            logger.LogError(e, "Exception while running unit of work, no changes have been made");
            throw;
        }
    }
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await dataContext.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
    }
}