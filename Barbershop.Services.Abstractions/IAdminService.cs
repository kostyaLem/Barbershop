using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;

namespace Barbershop.Services.Abstractions
{
    public interface IAdminService
    {
        Task<AdminDto> Login(string username, string password);

        Task<IReadOnlyList<AdminDto>> GetAll();

        Task Create(CreateAdminCommand command);

        Task RemoveById(int id);
    }
}
