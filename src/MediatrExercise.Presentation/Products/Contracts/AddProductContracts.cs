using Facet;
using MediatrExercise.Domain.Entities;

namespace MediatrExercise.Presentation.Products.Contracts;

[Facet(typeof(Product), exclude: [nameof(Product.Cart)])]
internal partial record AddProductRequest;