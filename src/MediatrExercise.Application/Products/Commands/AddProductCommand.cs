using MediatR;
using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MediatrExercise.Application.Products.Commands;

public record AddProductCommand(Product product) : IRequest<Product>;

public class AddProductCommandHandler(IUnitOfWork unitOfWork, ILogger<AddProductCommandHandler> logger) : IRequestHandler<AddProductCommand, Product>
{
    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        Product insertedProduct = await unitOfWork.ExecuteInUnitOfWorkAsync(async () =>
        {
            Product inserted = await unitOfWork.productRepository.AddAsync(request.product);
            logger.LogInformation("Created new product with id {id}", inserted.Id);
            return inserted;
        }, cancellationToken);
        return insertedProduct;
    }
}