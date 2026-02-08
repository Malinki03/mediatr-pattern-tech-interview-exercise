using MediatR;
using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;

namespace MediatrExercise.Application.Carts.Commands;

public record AddCartCommand(Cart cart) : IRequest<Cart>;

public class AddCartCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCartCommand, Cart>
{
    public async Task<Cart> Handle(AddCartCommand request, CancellationToken cancellationToken)
    {
        Cart insertedCart = await unitOfWork.ExecuteInUnitOfWorkAsync(async () =>
        {
            Cart inserted = await unitOfWork.cartRepository.AddAsync(request.cart);
            return inserted;
        }, cancellationToken);
        return insertedCart;
    }
}