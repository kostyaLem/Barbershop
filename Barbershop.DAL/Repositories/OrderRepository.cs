using Barbershop.DAL.Context;
using Barbershop.Domain.Models;

namespace Barbershop.DAL.Repositories;

internal class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(BarbershopContextFactory contextFactory) : base(contextFactory)
    {
    }

    public async Task CreateOrder(Order order)
    {
        using var context = _contextFactory.CreateContext();

        foreach (var service in order.ServiceSkillLevels)
        {
            context.Attach(service).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
        }

        context.Orders.Add(order);
        await context.SaveChangesAsync();
    }
}
