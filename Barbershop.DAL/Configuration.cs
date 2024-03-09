﻿using Barbershop.DAL.Context;
using Barbershop.DAL.Repositories;
using Barbershop.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Barbershop.DAL;

public static class Configuration
{
    public static ServiceCollection RegisterDataAccessLayerServies(this ServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<BarbershopContextFactory>();

        serviceCollection.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        return serviceCollection;
    }
}