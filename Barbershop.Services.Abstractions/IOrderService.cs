using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;

namespace Barbershop.Services.Abstractions;

public interface IOrderService
{
    Task Create(UpsertOrderCommand command);

    Task<IReadOnlyList<OrderDto>> GetAll();

    Task<IReadOnlyList<OrderDto>> GetAllBarberOrders(int barberId, bool doneOnly, DateTime startOfPeriod = default, DateTime endOfPeriod = default);

    Task<IReadOnlyList<OrderDto>> GetBarberSalary(int barberId, DateTime startOfPeriod = default, DateTime endOfPeriod = default);

    Task<IReadOnlyList<OrderDto>> GetBarberSpendTime(int barberId, DateTime startOfPeriod = default, DateTime endOfPeriod = default);

    Task Update(UpsertOrderCommand command);

    Task RemoveById(int id);
}