using Barbershop.UI.Services;
using Barbershop.UI.ViewModels;
using Barbershop.UI.ViewModels.Pages;
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
            
            serviceCollection.AddSingleton<AdminsPage>();
            serviceCollection.AddSingleton<AdminsPageViewModel>();

            return serviceCollection;
        }

        public static ServiceCollection RegisterExternalServices(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IWindowDialogService, WindowDialogService>();

            return serviceCollection;
        }
    }
}
