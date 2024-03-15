using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Services;

public sealed class OrderService : EntityService<OrderDto, Order, UpsertOrderCommand>
{
    public OrderService(IBaseRepository<Order> orderRepository, IMapper mapper)
        : base(orderRepository, mapper)
    {
    }

    public async Task CancelOrder(int orderId)
    {
        var order = await _entityRepository.GetById(orderId);
        order.OrderStatus = OrderStatus.Canceled;

        await _entityRepository.Update(order);
    }

    public async Task CompleteOrder(int orderId)
    {
        var order = await _entityRepository.GetById(orderId);
        order.OrderStatus = OrderStatus.Done;
        order.CompletedOn = DateTime.UtcNow;

        await _entityRepository.Update(order);
    }

    public override async Task<IReadOnlyList<OrderDto>> GetAll()
    {
        var orders = await _entityRepository.GetAll(
            x => x.Include(x => x.Barber)
                    .ThenInclude(x => x.User)
                .Include(x => x.Client)
                    .ThenInclude(x => x.User)
                .Include(x => x.ServiceSkillLevels)
                    .ThenInclude(x => x.Service)
                .Include(x => x.Products));

        return _mapper.Map<IReadOnlyList<OrderDto>>(orders);
    }
}
