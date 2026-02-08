using MediatrExercise.Domain.Entities;

namespace MediatrExercise.Domain.Repositories;

public interface IUnitOfWork : IAsyncDisposable
{
    //Properties
    public IGenericRepository<Cart> cartRepository { get; init; }
    public IGenericRepository<Product> productRepository { get; init; }

    //Methods
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    public Task ExecuteInUnitOfWorkAsync(Func<Task> action, CancellationToken cancellationToken = default);
    public Task<T> ExecuteInUnitOfWorkAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken = default);
}
