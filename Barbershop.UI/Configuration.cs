using Barbershop.UI.ViewModels;
using Barbershop.UI.Views;
using Barbershop.UI.Views.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace Barbershop.UI
{
    internal static class Configuration
    {
        public static ServiceCollection RegisterViews(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<AuthView>();
            serviceCollection.AddTransient<AuthViewModel>();

            serviceCollection.AddTransient<MainView>();
            serviceCollection.AddTransient<MainViewModel>();

            serviceCollection.AddPages();

            return serviceCollection;
        }

        private static ServiceCollection AddPages(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<MainPage>();

            return serviceCollection;
        }
    }
}
