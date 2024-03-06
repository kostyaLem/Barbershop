using Barbershop.DAL;
using Barbershop.UI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Barbershop.UI
{
    /// <summary>
    /// Класс для управления зависимостями сущностей.
    /// </summary>
    public static class Container
    {
        public static IServiceProvider ServiceProvider { get; }

        static Container()
        {
            ServiceProvider = CreateServiceCollection();
        }

        private static IServiceProvider CreateServiceCollection()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .RegisterDataAccessLayerServies()
                .RegisterViews();

            return serviceCollection.BuildServiceProvider();
        }

        public static void ShowWindow()
        {
            ServiceProvider.GetRequiredService<AuthView>().ShowDialog();
        }
    }
}
