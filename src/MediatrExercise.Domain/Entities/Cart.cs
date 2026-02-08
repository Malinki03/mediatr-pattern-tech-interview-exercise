namespace MediatrExercise.Domain.Entities;

public class Cart : Entity
{
    public virtual ICollection<Product>? Products { get; set; }

    public Cart(long id) : base(id) { }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }
}