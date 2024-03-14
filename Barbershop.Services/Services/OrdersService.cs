using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;

namespace Barbershop.Services;

public sealed class OrdersService : EntityService<OrderDto, Order, UpsertOrderCommand>
{
    public OrdersService(IBaseRepository<Order> orderRepository, IMapper mapper)
        : base(orderRepository, mapper)
    {

    }

    public override async Task<IReadOnlyList<OrderDto>> GetAll()
    {
        var orders = await _entityRepository.GetAll(
            x => x.ServiceSkillLevels,
            x => x.Products,
            x => x.Barber,
            x => x.Client);

        return _mapper.Map<IReadOnlyList<OrderDto>>(orders);
    }
}
