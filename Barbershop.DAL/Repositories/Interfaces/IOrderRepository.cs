using Barbershop.DAL.Models.ServicesAndProducts;

namespace Barbershop.DAL.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public void AddOrder(OrderModel order);

        public OrderModel GetOrder(int id);

        public ICollection<OrderModel> GetAllOrders();

        public ICollection<OrderModel> GetAllOrders(DateTime startPeriod, DateTime endPeriod);

        public void UpdateOrder(OrderModel order);

        public void DeleteOrder(int id);
    }
}