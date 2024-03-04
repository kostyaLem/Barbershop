using Barbershop.Domain.Models;
using Barbershop.Services.Abstractions;

namespace Barbershop.Services;

public class ProductService : IProductService
{
    public Task AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Product>> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProduct(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}