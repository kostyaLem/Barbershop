using Barbershop.UI.ViewModels;
using Barbershop.UI.Views.Pages;

namespace Barbershop.UI.Services;

public static class ViewItemsManager
{
    public static IReadOnlyList<ItemViewModel> GetItems(bool isAdmin = false)
    {
        if (true)
        {
            return new List<ItemViewModel>()
            {
                new("Главная", "HomeImage", typeof(MainPage)),
                new("Администраторы", "AdminImage", typeof(AdminsPage)),
                new("Товары", "ProductImage", typeof(ProductsPage)),
                new("Барберы", "BarberImage", typeof(BarbersPage)),
                new("Клиенты", "ClientImage", typeof(ClientsPage)),
                new("Услуги", "ServiceImage", typeof(ServicesPage)),
                //TODO: элементы ниже вынести для барбера
                new("Расписание", "ScheduleImage"),
                new("Зарплата", "SalaryImage")
            };
        }
    }
}
