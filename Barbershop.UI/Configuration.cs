using Barbershop.UI.ViewModels;
using Barbershop.UI.Views;
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

            return serviceCollection;
        }
    }
}
