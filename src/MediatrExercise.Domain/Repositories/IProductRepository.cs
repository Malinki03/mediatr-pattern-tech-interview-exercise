using MediatrExercise.Domain.Entities;

namespace MediatrExercise.Domain.Repositories;

public interface IProductRepository
{
    public Task<Product> GetById(long id);
    public Task<Product> Add(Product product);
}