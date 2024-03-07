using Barbershop.UI.ViewModels;

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
