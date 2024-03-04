using Barbershop.Domain.Models;

namespace Barbershop.Services.Abstractions;

public interface IAdminService
{
    public Task AddAdmin(Admin admin);

    public Task<Admin> GetAdmin(int id);

    public Task<IReadOnlyList<Admin>> GetAllAdmins();

    public Task UpdateAdmin(Admin admin);

    public Task UpdateAdminsPassword(int adminId, string password);

    public Task DeleteAdmin(int id);
}