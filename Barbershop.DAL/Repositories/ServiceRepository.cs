using Barbershop.DAL.Context;
using Barbershop.DAL.Exceptions;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;

namespace Barbershop.DAL.Repositories;

internal sealed class ServiceRepository : IServiceRepository
{
    private readonly BarbershopContextFactory _contextFactory;

    public ServiceRepository(BarbershopContextFactory contextFactory) => _contextFactory = contextFactory;

    public Task AddService(Service service)
    {
        using var context = _contextFactory.CreateDbContext();

        context.Services.Add(service);

        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task<Service> GetService(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var service = context.Services.FirstOrDefault(o => o.Id == id);

        NotFoundException.ThrowByPredicate(() => service == default(Service), "GetService operation failed, no service with such \"Id\" field");

        return Task.FromResult(service);
    }

    public Task<IReadOnlyList<Service>> GetAllServices()
    {
        using var context = _contextFactory.CreateDbContext();

        var products = (IReadOnlyList<Service>)context.Services;

        return Task.FromResult(products);
    }

    public Task UpdateService(Service service)
    {
        using var context = _contextFactory.CreateDbContext();

        var obsoleteService = context.Services.FirstOrDefault(o => o.Id == service.Id);

        NotFoundException.ThrowByPredicate(() => obsoleteService == default(Service), "UpdateService operation failed, no service with such \"Id\" field");

        obsoleteService = service;

        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task DeleteService(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var itemToRemove = context.Services.FirstOrDefault(x => x.Id == id);

        NotFoundException.ThrowByPredicate(() => itemToRemove == default(Service), "DeleteService operation failed, no service with such \"Id\" field");

        context.Services.Remove(itemToRemove);

        context.SaveChanges();

        return Task.CompletedTask;
    }
}