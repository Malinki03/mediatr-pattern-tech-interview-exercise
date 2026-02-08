using Facet;
using MediatrExercise.Domain.Entities;

namespace MediatrExercise.Presentation.Products.Contracts;

[Facet(typeof(Product), exclude: nameof(Product.CartId))]
internal partial record GetProductByIdResponse;