using System.Diagnostics.CodeAnalysis;

namespace MediatrExercise.Domain.Entities;

public class Product : Entity
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public long? CartId { get; set; }
    public virtual Cart? Cart { get; set; }

    [SetsRequiredMembers]
    public Product(long id, string name, decimal price) : base(id)
    {
        Name = name;
        Price = price;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || this.GetType() != obj.GetType()) return false;
        Product parsed = (Product)obj;
        return this.Id.Equals(parsed.Id);
    }
}