using Facet.Extensions;
using MediatR;
using MediatrExercise.Application.Products.Commands;
using MediatrExercise.Application.Products.Queries;
using MediatrExercise.Domain.Entities;
using MediatrExercise.Presentation.Products.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MediatrExercise.Presentation.Products.Endpoints;

public static class ProductEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/products/", GetProductById);
        app.MapPut("/products/", AddProduct);
    }

    private static async Task<Results<Ok<GetProductByIdResponse>, ProblemHttpResult>> GetProductById(long id, IMediator mediator)
    {
        var result = await mediator.Send(new GetProductByIdQuery(id));
        return TypedResults.Ok(result.ToFacet<Product, GetProductByIdResponse>());
    }

    private static async Task<Results<Created, ProblemHttpResult>> AddProduct(AddProductRequest request, IMediator mediator)
    {
        AddProductCommand command = new(new Product(request.Id, request.Name, request.Price));
        _ = await mediator.Send(command);
        return TypedResults.Created();
    }
}