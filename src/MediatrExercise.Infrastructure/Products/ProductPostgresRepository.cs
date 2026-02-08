using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MediatrExercise.Infrastructure.Products;

public class ProductPostgresRepository : IGenericRepository<Product>
{
    private readonly DataContext _dataContext;
    private readonly DbSet<Product> _dbSet;

    public ProductPostgresRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
        _dbSet = _dataContext.Set<Product>();
    }

    public async Task<Product> GetByIdAsync(long id)
    {
        Product? product = _dbSet.SingleOrDefault(p => p.Id == id);
        return product ?? throw new KeyNotFoundException($"Product with id {id} not found");
    }

    public async Task<Product> AddAsync(Product product)
    {
        _dbSet.Add(product);
        return product;
    }
}