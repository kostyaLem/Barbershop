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

            return serviceCollection;
        }
    }
}
