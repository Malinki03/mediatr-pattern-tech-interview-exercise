namespace MediatrExercise.Domain.Entities;

public class Cart : Entity
{
    private readonly List<Product> _products = [];
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    public Cart(long id) : base(id) { }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
}