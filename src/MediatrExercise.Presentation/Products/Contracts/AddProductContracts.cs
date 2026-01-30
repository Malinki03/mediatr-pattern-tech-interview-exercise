using Facet;
using MediatrExercise.Domain.Entities;

namespace MediatrExercise.Presentation.Products.Contracts;

[Facet(typeof(Product))]
public partial record AddProductRequest;