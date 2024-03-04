using Barbershop.Domain.Models;
using Barbershop.Services.Abstractions;

namespace Barbershop.Services;

public class OrderService : IOrderService
{
    public Task AddOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrder(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Order>> GetAllOrders()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Order>> GetAllOrders(DateTime? from, DateTime? to)
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetOrder(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrder(Order order)
    {
        throw new NotImplementedException();
    }
}