using MediatR;
using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MediatrExercise.Application.Products.Commands;

public record AddProductCommand(Product product) : IRequest<Product>;

public class AddProductCommandHandler(IProductRepository productRepository, ILogger<AddProductCommandHandler> logger) : IRequestHandler<AddProductCommand, Product>
{
    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        Product inserted = await productRepository.Add(request.product);
        logger.LogDebug("Created new product with id {id}", inserted.Id);
        return inserted;
    }
}