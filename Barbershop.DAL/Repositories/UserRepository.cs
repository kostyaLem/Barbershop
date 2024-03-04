using Barbershop.DAL.Context;
using Barbershop.DAL.Exceptions;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;

namespace Barbershop.DAL.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly BarbershopContextFactory _contextFactory;

    public UserRepository(BarbershopContextFactory contextFactory) => _contextFactory = contextFactory;

    public Task AddAdmin(Admin user)
    {
        using var context = _contextFactory.CreateDbContext();

        context.Admins.Add(user);

        context.SaveChanges();

        return Task.CompletedTask;
    }
    public Task AddClient(Client user)
    {
        using var context = _contextFactory.CreateDbContext();

        context.Clients.Add(user);

        context.SaveChanges();

        return Task.CompletedTask;
    }
    public Task AddBarber(Barber user)
    {
        using var context = _contextFactory.CreateDbContext();

        context.Barbers.Add(user);

        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task<Admin> GetAdmin(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var user = context.Admins.FirstOrDefault(o => o.Id == id);

        NotFoundException.ThrowByPredicate(() => user == default(Admin), "GetAdmin operation failed, no admin with such \"Id\" field");

        return Task.FromResult(user);
    }
    public Task<Client> GetClient(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var user = context.Clients.FirstOrDefault(o => o.Id == id);

        NotFoundException.ThrowByPredicate(() => user == default(Client), "GetClient operation failed, no client with such \"Id\" field");

        return Task.FromResult(user);
    }
    public Task<Barber> GetBarber(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var user = context.Barbers.FirstOrDefault(o => o.Id == id);

        NotFoundException.ThrowByPredicate(() => user == default(Barber), "GetBarber operation failed, no barber with such \"Id\" field");

        return Task.FromResult(user);
    }

    public Task<IReadOnlyList<Admin>> GetAllAdmins()
    {
        using var context = _contextFactory.CreateDbContext();

        var admins = (IReadOnlyList<Admin>)context.Admins;

        return Task.FromResult(admins);
    }
    public Task<IReadOnlyList<Client>> GetAllClients()
    {
        using var context = _contextFactory.CreateDbContext();

        var clients = (IReadOnlyList<Client>)context.Clients;

        return Task.FromResult(clients);
    }
    public Task<IReadOnlyList<Barber>> GetAllBarbers()
    {
        using var context = _contextFactory.CreateDbContext();

        var barbers = (IReadOnlyList<Barber>)context.Barbers;

        return Task.FromResult(barbers);
    }

    public Task<IReadOnlyList<Barber>> GetBarbers(SkillLevel barberSkillLevel)
    {
        using var context = _contextFactory.CreateDbContext();

        var barbers = (IReadOnlyList<Barber>)context.Barbers.Where(x => x.SkillLevel == barberSkillLevel);

        return Task.FromResult(barbers);
    }

    //Оставил эти запросы к бд в таком виде, а не в виде одного LINQ запроса, чтобы дебажить
    public Task<IReadOnlyList<Order>> GetBarbersWorkSchedule(int barberId, DateTime? from, DateTime? to, bool doneOnly = false)
    {
        using var context = _contextFactory.CreateDbContext();

        var barber = context.Barbers.Where(x => x.Id == barberId).FirstOrDefault();

        NotFoundException.ThrowByPredicate(() => barber == default(Barber), "GetBarbersWorkSchedule operation failed, no barber with such \"Id\" field");

        var orders = barber.Orders.Where(x => x.CompletedOn > from && x.CompletedOn < to);

        var result = doneOnly ? (IReadOnlyList<Order>)orders.Where(x => x.CompletedOn != default(DateTime)) : (IReadOnlyList<Order>)orders;

        return Task.FromResult(result);
    }

    public Task UpdateAdmin(Admin user)
    {
        using var context = _contextFactory.CreateDbContext();

        var obsoleteUser = context.Admins.FirstOrDefault(o => o.Id == user.Id);

        NotFoundException.ThrowByPredicate(() => obsoleteUser == default(Admin), "UpdateAdmin operation failed, no admin with such \"Id\" field");

        obsoleteUser = user;

        context.SaveChanges();

        return Task.CompletedTask;
    }
    public Task UpdateClient(Client user)
    {
        using var context = _contextFactory.CreateDbContext();

        var obsoleteUser = context.Clients.FirstOrDefault(o => o.Id == user.Id);

        NotFoundException.ThrowByPredicate(() => obsoleteUser == default(Client), "UpdateClient operation failed, no client with such \"Id\" field");

        obsoleteUser = user;

        context.SaveChanges();

        return Task.CompletedTask;
    }
   
    public Task UpdateBarber(Barber user)
    {
        using var context = _contextFactory.CreateDbContext();

        var obsoleteUser = context.Barbers.FirstOrDefault(o => o.Id == user.Id);

        NotFoundException.ThrowByPredicate(() => obsoleteUser == default(Barber), "UpdateBarber operation failed, no barber with such \"Id\" field");

        obsoleteUser = user;

        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task UpdateClientNotes(int userId, string notes)
    {
        using var context = _contextFactory.CreateDbContext();

        var obsoleteUser = context.Clients.FirstOrDefault(o => o.Id == userId);

        NotFoundException.ThrowByPredicate(() => obsoleteUser == default(Client), "UpdateClientNotes operation failed, no client with such \"Id\" field");

        obsoleteUser.Notes = notes;

        context.SaveChanges();

        return Task.CompletedTask;
    }
   
    public Task UpdateAdminPassword(int userId, string password)
    {
        using var context = _contextFactory.CreateDbContext();

        var obsoleteUser = context.Admins.FirstOrDefault(o => o.Id == userId);

        NotFoundException.ThrowByPredicate(() => obsoleteUser == default(Admin), "UpdateAdminPassword operation failed, no admin with such \"Id\" field");

        obsoleteUser.PasswordHash = password.GetPasswordHash();

        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task UpdateBarberPassword(int userId, string password)
    {
        using var context = _contextFactory.CreateDbContext();

        var obsoleteUser = context.Barbers.FirstOrDefault(o => o.Id == userId);

        NotFoundException.ThrowByPredicate(() => obsoleteUser == default(Barber), "UpdateBarberPassword operation failed, no barber with such \"Id\" field");

        obsoleteUser.PasswordHash = password.GetPasswordHash();

        context.SaveChanges();

        return Task.CompletedTask;
    }


    public Task DeleteAdmin(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var itemToRemove = context.Admins.FirstOrDefault(x => x.Id == id);

        NotFoundException.ThrowByPredicate(() => itemToRemove == default(Admin), "DeleteAdmin operation failed, no admin with such \"Id\" field");

        context.Admins.Remove(itemToRemove);

        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task DeleteClient(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var itemToRemove = context.Clients.FirstOrDefault(x => x.Id == id);

        NotFoundException.ThrowByPredicate(() => itemToRemove == default(Client), "DeleteClient operation failed, no client with such \"Id\" field");

        context.Clients.Remove(itemToRemove);

        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task DeleteBarber(int id)
    {
        using var context = _contextFactory.CreateDbContext();

        var itemToRemove = context.Barbers.FirstOrDefault(x => x.Id == id);

        NotFoundException.ThrowByPredicate(() => itemToRemove == default(Barber), "DeleteBarber operation failed, no barber with such \"Id\" field");

        context.Barbers.Remove(itemToRemove);

        context.SaveChanges();

        return Task.CompletedTask;
    }
}