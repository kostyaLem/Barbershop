using Barbershop.DAL.Models.ServicesAndProducts;

namespace Barbershop.DAL.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        public void AddService(ServiceModel service);

        public ServiceModel GetService(int id);

        public ICollection<ServiceModel> GetAllServices();

        public void UpdateService(ServiceModel service);

        public void DeleteService(int id);
    }
}