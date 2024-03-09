using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;

namespace Barbershop.Services.Abstractions;

public interface IClientService
{
    Task Create(UpsertClientCommand command);

    Task<IReadOnlyList<ClientDto>> GetAll();

    Task Update(UpsertClientCommand command);

    Task RemoveById(int id);
}