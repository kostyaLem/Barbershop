using Barbershop.DAL.Models.ServicesAndProducts;
using Barbershop.Domain.Models;

namespace Barbershop.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public void AddProduct(ProductModel product);

        public ProductModel GetProduct(int id);

        public ICollection<ProductModel> GetAllProducts();

        public void UpdateProduct(ProductModel product);

        public void DeleteProduct(int id);
    }
}