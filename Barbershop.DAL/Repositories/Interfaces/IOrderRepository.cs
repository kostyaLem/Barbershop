using Barbershop.DAL.Models;

namespace Barbershop.DAL.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task AddOrder(OrderModel order);

        public Task<OrderModel> GetOrder(int id);

        public Task<IReadOnlyList<OrderModel>> GetAllOrders();

        public Task<IReadOnlyList<OrderModel>> GetAllOrders(DateTime? from, DateTime? to);

        public Task UpdateOrder(OrderModel order);

        public Task DeleteOrder(int id);
    }
}