using Barbershop.UI.ViewModels;
using Barbershop.UI.Views.Pages;

namespace Barbershop.UI.Services;

public static class ViewItemsManager
{
    public static IReadOnlyList<ItemModel> GetItems(bool isAdmin = false)
    {
        if (true)
        {
            return new List<ItemModel>()
            {
                new("Главная", "HomeImage", typeof(MainPage)),
                new("Администраторы", "AdminImage", typeof(AdminsPage)),
                new("Товары", "ProductImage", typeof(ProductsPage)),
                new("Барберы", "BarberImage", typeof(BarbersPage)),
                new("Клиенты", "ClientImage", typeof(ClientsPage)),
                new("Услуги", "ServiceImage", typeof(ServicesPage)),
                new("Заказы", "SalaryImage", typeof(OrdersPage)),
                new("Расписание", "ScheduleImage"),
                new("Зарплата", "SalaryImage")
            };
        }
    }
}
