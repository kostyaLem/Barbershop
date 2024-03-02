using Barbershop.DAL.Repositories;
using Barbershop.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Barbershop.DAL
{
    public static class IocConfiguration
    {
        public static ServiceCollection AddDependencies(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            serviceCollection.AddTransient<IServiceRepository, ServiceRepository>();
            serviceCollection.AddTransient<IOrderRepository, OrderRepository>();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();

            return serviceCollection;
        }
    }
}
