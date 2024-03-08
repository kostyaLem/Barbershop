using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;

namespace Barbershop.Services.Abstractions;

public interface IBarberService
{
    Task<BarberDto> Login(string username, string password);

    Task<IReadOnlyList<BarberDto>> GetAll();

    Task Create(CreateBarberCommand command);

    Task RemoveById(int id);
}