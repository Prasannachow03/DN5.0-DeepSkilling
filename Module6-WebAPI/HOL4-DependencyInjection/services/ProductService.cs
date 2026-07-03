namespace HOL4_DependencyInjection.Services;
public class ProductService : IProductService
{
    private readonly List<string> _products = new() { "Laptop", "Phone", "Tablet" };

    public IEnumerable<string> GetAll() => _products;
    public string GetById(int id) => id >= 1 && id <= _products.Count ? _products[id - 1] : null;
    public void Add(string product) => _products.Add(product);
}