using MediatrExercise.Domain.Repositories;

namespace MediatrExercise.Infrastructure;

public class UnitOfWork(IProductRepository productRepository, ICartRepository cartRepository) : IUnitOfWork
{
    public ICartRepository cartRepository { get; init; } = cartRepository;
    public IProductRepository productRepository { get; init; } = productRepository;

    public async Task ExecuteInUnitOfWorkAsync(Func<Task> action, CancellationToken cancellationToken = default)
    {
        await action();
        SaveChangesAsync(cancellationToken);
    }
    public async Task<T> ExecuteInUnitOfWorkAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken = default)
    {
        var result = await action();
        SaveChangesAsync(cancellationToken);
        return result;
    }
    
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}