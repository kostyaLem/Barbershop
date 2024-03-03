using Barbershop.Domain.Models;

namespace Barbershop.Domain.Repositories
{
    public interface IServiceRepository
    {
        public Task AddService(Service service);

        public Task<Service> GetService(int id);

        public Task<IReadOnlyList<Service>> GetAllServices();

        public Task UpdateService(Service service);

        public Task DeleteService(int id);
    }
}