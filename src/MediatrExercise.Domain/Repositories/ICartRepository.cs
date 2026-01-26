using MediatrExercise.Domain.Entities;

namespace MediatrExercise.Domain.Repositories;

public interface ICartRepository
{
    public Task<Cart> GetById(long id);
    public Task<Cart> Add(Cart cart);
}