using Barbershop.Domain.Models;

namespace Barbershop.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task AddUser(User user);

        public Task<Admin> GetAdmin(int id);
        public Task<Client> GetClient(int id);
        public Task<Barber> GetBarber(int id);

        public Task<IReadOnlyList<Admin>> GetAdmins();
        public Task<IReadOnlyList<Client>> GetClients();
        public Task<IReadOnlyList<Barber>> GetBarbers();

        public Task<IReadOnlyList<Barber>> GetBarbers(SkillLevel usersSkillLevel);

        public Task<IReadOnlyList<Order>> GetBarbersWorkSchedule(int barberId, DateTime? startPeriod, DateTime? endPeriod, bool doneOnly = false);

        public Task UpdateUser(User user);

        public Task UpdateUserNotes(int userId, string notes);

        public Task UpdateUserPassword(int userId, string password);

        public Task DeleteUser(int id);
    }
}