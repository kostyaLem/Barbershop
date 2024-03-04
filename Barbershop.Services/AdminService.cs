using Barbershop.Domain.Models;
using Barbershop.Services.Abstractions;

namespace Barbershop.Services;

public class AdminService : IAdminService
{
    public Task AddAdmin(Admin admin)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAdmin(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Admin> GetAdmin(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Admin>> GetAllAdmins()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAdmin(Admin admin)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAdminsPassword(int adminId, string password)
    {
        throw new NotImplementedException();
    }
}