using MediatR;
using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;

namespace MediatrExercise.Application.Products.Commands;

public record AddProductCommand(Product product) : IRequest<Product>;

public class AddProductCommandHandler(IProductRepository productRepository) : IRequestHandler<AddProductCommand, Product>
{
    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        Product inserted = await productRepository.Add(request.product);
        return inserted;
    }
}