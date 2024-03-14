﻿using Barbershop.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Barbershop.Services;

public static class Configuration
{
    public static ServiceCollection RegisterServices(this ServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IAuthService, AuthService>();
        serviceCollection.AddTransient(typeof(IEntityService<,,>), typeof(EntityService<,,>));

        serviceCollection.AddTransient<ProductService>();
        serviceCollection.AddTransient<ClientService>();
        serviceCollection.AddTransient<BarberService>();
        serviceCollection.AddTransient<AdminService>();
        serviceCollection.AddTransient<OfferService>();
        serviceCollection.AddTransient<OrdersService>();

        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());

        return serviceCollection;
    }
}