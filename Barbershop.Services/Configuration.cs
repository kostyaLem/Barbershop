using Barbershop.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Barbershop.Services
{
    public static class Configuration
    {
        public static ServiceCollection RegisterServices(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAdminService, AdminService>();

            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());

            return serviceCollection;
        }
    }
}
