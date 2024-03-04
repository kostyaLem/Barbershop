using Barbershop.Domain.Models;

namespace Barbershop.Services.Abstractions;

public interface IOrderService
{
    public Task AddOrder(Order order);

    public Task<Order> GetOrder(int id);

    public Task<IReadOnlyList<Order>> GetAllOrders();

    public Task<IReadOnlyList<Order>> GetAllOrders(DateTime? from, DateTime? to);

    public Task UpdateOrder(Order order);

    public Task DeleteOrder(int id);
}