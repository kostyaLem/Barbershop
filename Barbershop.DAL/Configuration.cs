using Microsoft.Extensions.DependencyInjection;

namespace Barbershop.DAL
{
    public static class Configuration
    {
        public static ServiceCollection RegisterDataAccessLayerServies(this ServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
