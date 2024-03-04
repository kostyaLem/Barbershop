using Barbershop.DAL.Context;
using Barbershop.DAL.Exceptions;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;

namespace Barbershop.DAL.Repositories;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly BarbershopContextFactory _contextFactory;

    public OrderRepository(BarbershopContextFactory contextFactory) => _contextFactory = contextFactory;


    //Нужно ли оборачивать эти методы в трайкеч? А то мало ли
    public Task AddOrder(Order order)
    {
        using var context = _contextFactory.CreateDbContext();

        context.Orders.Add(order);

        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task<Order> GetOrder(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var order = context.Orders.FirstOrDefault(o => o.Id == id);

        NotFoundException.ThrowByPredicate(() => order == default(Order), "GetOrder operation failed, no order with such \"Id\" field");

        return Task.FromResult(order);
    }

    //Решил тут и в следующем методе ошибку не проверять. Если коллекция пуста - то это, по сути, может быть корректным поведением.
    public Task<IReadOnlyList<Order>> GetAllOrders()
    {
        using var context = _contextFactory.CreateDbContext();

        var orders = (IReadOnlyList<Order>)context.Orders;

        return Task.FromResult(orders);
    }

    public Task<IReadOnlyList<Order>> GetAllOrders(DateTime? from, DateTime? to)
    {
        using var context = _contextFactory.CreateDbContext();

        var orders = (IReadOnlyList<Order>)context.Orders.Where(x => x.CompletedOn > from && x.CompletedOn < to);

        return Task.FromResult(orders);
    }

    public Task UpdateOrder(Order order)
    {
        using var context = _contextFactory.CreateDbContext();

        var obsoleteOrder = context.Orders.FirstOrDefault(o => o.Id == order.Id);

        NotFoundException.ThrowByPredicate(() => obsoleteOrder == default(Order), "UpdateOrder operation failed, no order with such \"Id\" field");

        obsoleteOrder = order;

        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task DeleteOrder(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var itemToRemove = context.Orders.FirstOrDefault(x => x.Id == id);

        NotFoundException.ThrowByPredicate(() => itemToRemove == default(Order), "DeleteOrder operation failed, no order with such \"Id\" field");

        context.Orders.Remove(itemToRemove);

        context.SaveChanges();

        return Task.CompletedTask;
    }
}