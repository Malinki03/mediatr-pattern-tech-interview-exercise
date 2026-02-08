using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MediatrExercise.Infrastructure.Carts;

public class CartPostgresRepository : IGenericRepository<Cart>
{
    private readonly DataContext _dbContext;
    private readonly DbSet<Cart> _dbSet;

    public CartPostgresRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<Cart>();
    }

    public async Task<Cart> GetByIdAsync(long id)
    {
        Cart cart = _dbSet.SingleOrDefault(c => c.Id == id);
        return cart ?? throw new KeyNotFoundException($"Cart with id {id} not found");
    }

    public async Task<Cart> AddAsync(Cart cart)
    {
        _dbSet.Add(cart);
        return cart;
    }
}