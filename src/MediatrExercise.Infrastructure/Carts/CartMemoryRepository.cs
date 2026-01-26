using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;

namespace MediatrExercise.Infrastructure.Carts;

public class CartMemoryRepository : ICartRepository
{
    private static readonly HashSet<Cart> InMemoryCarts = [];
    
    public async Task<Cart> GetById(long id)
    {
        Cart cart = InMemoryCarts.SingleOrDefault(c => c.Id == id);
        return cart ?? throw new KeyNotFoundException($"Cart with id {id} not found");
    }

    public async Task<Cart> Add(Cart cart)
    {
        InMemoryCarts.Add(cart);
        return cart;
    }
}