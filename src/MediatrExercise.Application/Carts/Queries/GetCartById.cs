using MediatR;
using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;

namespace MediatrExercise.Application.Carts.Queries;

public record GetCartByIdQuery(long id) : IRequest<Cart>;

public class GetCartByIdHandler(IGenericRepository<Cart> cartRepository) : IRequestHandler<GetCartByIdQuery, Cart>
{
    public async Task<Cart> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
    {
        Cart retrieved = await cartRepository.GetByIdAsync(request.id);
        return retrieved;
    }
}