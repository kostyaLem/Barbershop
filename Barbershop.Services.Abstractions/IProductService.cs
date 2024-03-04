using Barbershop.Domain.Models;

namespace Barbershop.Services.Abstractions;

public interface IProductService
{
    public Task AddProduct(Product product);

    public Task<Product> GetProduct(int id);

    public Task<IReadOnlyList<Product>> GetAllProducts();

    public Task UpdateProduct(Product product);

    public Task DeleteProduct(int id);
}