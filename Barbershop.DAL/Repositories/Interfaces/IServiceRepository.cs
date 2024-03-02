using Barbershop.DAL.Models;

namespace Barbershop.DAL.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        public Task AddService(ServiceModel service);

        public Task<ServiceModel> GetService(int id);

        public Task<IReadOnlyList<ServiceModel>> GetAllServices();

        public Task UpdateService(ServiceModel service);

        public Task DeleteService(int id);
    }
}