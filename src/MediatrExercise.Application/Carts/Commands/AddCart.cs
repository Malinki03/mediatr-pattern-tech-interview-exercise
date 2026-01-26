using MediatR;
using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;

namespace MediatrExercise.Application.Carts.Commands;

public record AddCartCommand(Cart cart) : IRequest<Cart>;

public class AddCartCommandHandler(ICartRepository cartRepository) : IRequestHandler<AddCartCommand, Cart>
{
    public async Task<Cart> Handle(AddCartCommand request, CancellationToken cancellationToken)
    {
        Cart inserted = await cartRepository.Add(request.cart);
        return inserted;
    }
}