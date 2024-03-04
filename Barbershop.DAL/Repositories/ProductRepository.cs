using Barbershop.DAL.Context;
using Barbershop.DAL.Exceptions;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;

namespace Barbershop.DAL.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly BarbershopContextFactory _contextFactory;

    public ProductRepository(BarbershopContextFactory contextFactory) => _contextFactory = contextFactory;

    public Task AddProduct(Product product)
    {
        using var context = _contextFactory.CreateDbContext();

        context.Products.Add(product);

        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task<Product> GetProduct(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var product = context.Products.FirstOrDefault(o => o.Id == id);

        NotFoundException.ThrowByPredicate(() => product == default(Product), "GetProduct operation failed, no product with such \"Id\" field");

        return Task.FromResult(product);
    }

    public Task<IReadOnlyList<Product>> GetAllProducts()
    {
        using var context = _contextFactory.CreateDbContext();

        var products = (IReadOnlyList<Product>)context.Products;

        return Task.FromResult(products);
    }

    public Task UpdateProduct(Product product)
    {
        using var context = _contextFactory.CreateDbContext();

        var obsoleteProduct = context.Products.FirstOrDefault(o => o.Id == product.Id);

        NotFoundException.ThrowByPredicate(() => obsoleteProduct == default(Product), "UpdateProduct operation failed, no product with such \"Id\" field");

        obsoleteProduct = product;

        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task DeleteProduct(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var itemToRemove = context.Products.FirstOrDefault(x => x.Id == id);

        NotFoundException.ThrowByPredicate(() => itemToRemove == default(Product), "DeleteProduct operation failed, no product with such \"Id\" field");

        context.Products.Remove(itemToRemove);

        context.SaveChanges();

        return Task.CompletedTask;
    }
}