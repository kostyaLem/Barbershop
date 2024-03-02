using Barbershop.DAL.Models.ServicesAndProducts;
using Barbershop.DAL.Models.UserModels;
using Barbershop.Domain.Models;

namespace Barbershop.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public void AddUser(UserModel user);

        // Тут апкаст, возвращать будем барбера, админа или клиента, в зависимости от типа сущности
        public UserModel GetUser(int id);

        public ICollection<UserModel> GetAllUsers();

        //Можно было бы сделать подобный отдельный метод для каждого типа юзеров, но хз надо ли
        public ICollection<BarberModel> GetBarbers(SkillLevel usersSkillLevel);

        //Этот метод покрывает все необходимые запросы из ТЗ, но можно и разбить/добавить на несколько более точечных
        public ICollection<OrderModel> GetBarbersWorkSchedule(int barberId, DateTime startPeriod, DateTime endPeriod, bool doneOnly = false);

        // Тут даункаст, внутри проверим является ли UserModel кем-то из наследников - если да - ок, обновляем.
        public void UpdateUser(UserModel user);

        public void DeleteUser(int id);
    }
}