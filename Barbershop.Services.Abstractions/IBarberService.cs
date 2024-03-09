using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;

namespace Barbershop.Services.Abstractions;

public interface IBarberService
{
    Task<BarberDto> Login(string username, string password);

    Task Create(UpsertBarberCommand command);

    Task<IReadOnlyList<BarberDto>> GetAll();

    Task Update(UpsertBarberCommand command);

    Task RemoveById(int id);
}