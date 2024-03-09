using Barbershop.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Barbershop.Services;

public static class Configuration
{
    public static ServiceCollection RegisterServices(this ServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IAuthService, AuthService>();
        serviceCollection.AddSingleton<IAdminService, AdminService>();
        serviceCollection.AddSingleton<IProductService, ProductService>();

        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());

        return serviceCollection;
    }
}