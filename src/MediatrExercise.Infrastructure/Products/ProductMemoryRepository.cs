using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;
    
namespace MediatrExercise.Infrastructure.Products;

public class ProductMemoryRepository : IProductRepository
{
    private static readonly HashSet<Product> InMemoryProducts = [];
    
    public async Task<Product> GetById(long id)
    {
        Product product = InMemoryProducts.SingleOrDefault(p => p.Id == id);
        return product ?? throw new KeyNotFoundException($"Product with id {id} not found");
    }

    public async Task<Product> Add(Product product)
    {
        InMemoryProducts.Add(product);
        return product;
    }
}