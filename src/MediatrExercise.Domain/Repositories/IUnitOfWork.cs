namespace MediatrExercise.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    //Properties
    public ICartRepository cartRepository { get; init; }
    public IProductRepository productRepository { get; init; }

    //Methods
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    public Task ExecuteInUnitOfWorkAsync(Func<Task> action, CancellationToken cancellationToken = default);
    public Task<T> ExecuteInUnitOfWorkAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken = default);
}
