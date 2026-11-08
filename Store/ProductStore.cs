using M8E1.Model;

namespace M8E1.Store;

public class ProductStore
{
    private readonly List<Product> _products = [
        new () {Id = Guid.NewGuid(), Name = "Ice-Cream", Price = 3.99m},
        new () {Id = Guid.NewGuid(), Name = "Soda", Price = 2.99m},
        new () {Id = Guid.NewGuid(), Name = "Pizza", Price = 6.99m},
        new () {Id = Guid.NewGuid(), Name = "عصيد", Price = 7.99m},
        new () {Id = Guid.NewGuid(), Name = "Chechen Frize", Price = 3.99m},
        new () {Id = Guid.NewGuid(), Name = "Water", Price = 0.99m},
        new () {Id = Guid.NewGuid(), Name = "Lemon", Price = 1.99m},
        new () {Id = Guid.NewGuid(), Name = "Burger", Price = 3.99m},
        new () {Id = Guid.NewGuid(), Name = "Chips", Price = 5.99m},
        new () {Id = Guid.NewGuid(), Name = "Kebab", Price = 4.99m},
        new () {Id = Guid.NewGuid(), Name = "Coffee", Price = 2.99m},
    ];

    public IEnumerable<Product> GetAll() => _products;
    public Product? GetById(Guid id) => _products.FirstOrDefault(p => p.Id == id);

    public void Add(Product product) => _products.Add(product);
    public bool Update(Product product)
    {
        var existing = _products.FirstOrDefault(p=>p.Id==product.Id);

        if (existing is null) return false;

        existing.Name = product.Name;
        existing.Price = product.Price;

        return true;

    }

    public bool Delete(Product product)
    {
        var existing = _products.FirstOrDefault(p=>p.Id==product.Id);
        return existing != null && _products.Remove(product); 
    }
}