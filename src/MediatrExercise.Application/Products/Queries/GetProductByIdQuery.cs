using MediatR;
using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;

namespace MediatrExercise.Application.Products.Queries;

public record GetProductByIdQuery(long id) : IRequest<Product>;

public class GetProductByIdHandler(IGenericRepository<Product> productRepository) : IRequestHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product retrieved = await productRepository.GetByIdAsync(request.id);
        return retrieved;
    }
}