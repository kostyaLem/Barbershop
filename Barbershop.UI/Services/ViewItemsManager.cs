using Barbershop.UI.ViewModels;
using Barbershop.UI.Views.Pages;

namespace Barbershop.UI.Services
{
    public static class ViewItemsManager
    {
        public static IReadOnlyList<ItemViewModel> GetItems(bool isAdmin = false)
        {
            if (true)
            {
                return new List<ItemViewModel>()
                {
                    new("Главная", "HomeImage", typeof(MainPage)),
                    new("Барберы", "BarberImage"),
                    new("Клиенты", "ClientImage"),
                    new("Администраторы", "AdminImage"),
                    new("Услуги", "ServiceImage"),
                    new("Товары", "ProductImage"),
                    //TODO: элементы ниже вынести для барбера
                    new("Расписание", "ScheduleImage"),
                    new("Зарплата", "SalaryImage")
                };
            }
        }
    }
}
