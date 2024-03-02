using Barbershop.DAL.Models;
using Barbershop.Domain.Models;

namespace Barbershop.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task AddUser(UserModel user);

        public Task<AdminModel> GetAdmin(int id);
        public Task<ClientModel> GetClient(int id);
        public Task<BarberModel> GetBarber(int id);

        public Task<IReadOnlyList<AdminModel>> GetAdmins();
        public Task<IReadOnlyList<ClientModel>> GetClients();
        public Task<IReadOnlyList<BarberModel>> GetBarbers();

        public Task<IReadOnlyList<BarberModel>> GetBarbers(SkillLevel usersSkillLevel);

        public Task<IReadOnlyList<OrderModel>> GetBarbersWorkSchedule(int barberId, DateTime? startPeriod, DateTime? endPeriod, bool doneOnly = false);

        public Task UpdateUser(UserModel user);

        public Task UpdateUserNotes(int userId, string notes);

        public Task UpdateUserPassword(int userId, string password);

        public Task DeleteUser(int id);
    }
}