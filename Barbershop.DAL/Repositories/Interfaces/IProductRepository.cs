using Barbershop.DAL.Models;

namespace Barbershop.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task AddProduct(ProductModel product);

        public Task<ProductModel> GetProduct(int id);

        public Task<IReadOnlyList<ProductModel>> GetAllProducts();

        public Task UpdateProduct(ProductModel product);

        public Task DeleteProduct(int id);
    }
}