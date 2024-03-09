using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Barbershop.Services.Abstractions;

namespace Barbershop.Services;

public class OrderService : IOrderService
{
    private readonly IBaseRepository<Order> _orderRepository;

    private readonly IMapper _mapper;

    public OrderService(IBaseRepository<Order> barberRepo, IMapper mapper)
    {
        _orderRepository = barberRepo ?? throw new ArgumentNullException(nameof(barberRepo));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Create(UpsertOrderCommand command)
    {
        var order = _mapper.Map<Order>(command);

        await _orderRepository.Add(order);
    }

    public async Task<IReadOnlyList<OrderDto>> GetAll()
    {
        var orders = await _orderRepository.GetAll();

        return _mapper.Map<IReadOnlyList<OrderDto>>(orders);
    }
    
    public Task<IReadOnlyList<OrderDto>> GetAllBarberOrders(int barberId, bool doneOnly, DateTime startOfPeriod = default, DateTime endOfPeriod = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<OrderDto>> GetBarberSalary(int barberId, DateTime startOfPeriod = default, DateTime endOfPeriod = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<OrderDto>> GetBarberSpendTime(int barberId, DateTime startOfPeriod = default, DateTime endOfPeriod = default)
    {
        throw new NotImplementedException();
    }

    public async Task Update(UpsertOrderCommand command)
    {
        await _orderRepository.Update(_mapper.Map<Order>(command));
    }

    public async Task RemoveById(int id)
    {
        await _orderRepository.Remove(id);
    }      
}