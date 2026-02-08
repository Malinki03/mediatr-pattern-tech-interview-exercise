namespace MediatrExercise.Domain.Repositories;

public interface IGenericRepository<T>
{
    public Task<T> GetByIdAsync(long id);
    public Task<T> AddAsync(T entity);
}