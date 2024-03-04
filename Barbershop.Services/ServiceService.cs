using Barbershop.Domain.Models;
using Barbershop.Services.Abstractions;

namespace Barbershop.Services;

public class ServiceService : IServiceService
{
    public Task AddService(Service service)
    {
        throw new NotImplementedException();
    }

    public Task DeleteService(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Service>> GetAllServices()
    {
        throw new NotImplementedException();
    }

    public Task<Service> GetService(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateService(Service service)
    {
        throw new NotImplementedException();
    }
}