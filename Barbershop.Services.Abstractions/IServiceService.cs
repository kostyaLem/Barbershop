using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;

namespace Barbershop.Services.Abstractions;

public interface IServiceService
{
    Task Create(UpsertServiceCommand command);

    Task<IReadOnlyList<ServiceDto>> GetAll();

    Task Update(UpsertServiceCommand command);

    Task RemoveById(int id);
}