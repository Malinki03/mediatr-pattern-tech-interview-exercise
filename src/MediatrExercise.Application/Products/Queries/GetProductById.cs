using MediatR;
using MediatrExercise.Domain.Entities;
using MediatrExercise.Domain.Repositories;

namespace MediatrExercise.Application.Products.Queries;

public record GetProductByIdQuery(long id) : IRequest<Product>;

public class GetProductByIdHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product retrieved = await productRepository.GetById(request.id);
        return retrieved;
    }
}