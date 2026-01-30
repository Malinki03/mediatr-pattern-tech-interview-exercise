using MediatR;
using MediatrExercise.Application.Products.Queries;
using MediatrExercise.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MediatrExercise.Presentation.Endpoints;

public static class ProductEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/products/", GetProductById);
    }

    private static async Task<Results<Ok<Product>, ProblemHttpResult>> GetProductById(long id, IMediator mediator)
    {
        var result = await mediator.Send(new GetProductByIdQuery(id));
        return TypedResults.Ok(result);
    }
}