using Barbershop.Domain.Models;

namespace Barbershop.Domain.Repositories;

public interface IUserRepository
{
    public Task AddAdmin(Admin user);
    public Task AddClient(Client user);
    public Task AddBarber(Barber user);

    public Task<Admin> GetAdmin(int id);
    public Task<Client> GetClient(int id);
    public Task<Barber> GetBarber(int id);

    public Task<IReadOnlyList<Admin>> GetAllAdmins();
    public Task<IReadOnlyList<Client>> GetAllClients();
    public Task<IReadOnlyList<Barber>> GetAllBarbers();

    public Task<IReadOnlyList<Barber>> GetBarbers(SkillLevel usersSkillLevel);

    public Task<IReadOnlyList<Order>> GetBarbersWorkSchedule(int barberId, DateTime? from, DateTime? to, bool doneOnly = false);

    public Task UpdateAdmin(Admin user);
    public Task UpdateClient(Client user);
    public Task UpdateBarber(Barber user);

    public Task UpdateClientNotes(int userId, string notes);

    public Task UpdateAdminPassword(int userId, string password);
    public Task UpdateBarberPassword(int userId, string password);

    public Task DeleteAdmin(int id);
    public Task DeleteClient(int id);
    public Task DeleteBarber(int id);
}