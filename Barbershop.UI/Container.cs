using AutoMapper;
using Barbershop.DAL;
using Barbershop.Services;
using Barbershop.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Windows;

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
                .RegisterServices()
                .RegisterViews();
            
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());

            return serviceCollection.BuildServiceProvider();
        }

        public static void PrepareApp()
        {
            Task.Run(() => ServiceProvider.Migrate()).Wait();
        }

        public static void ShowView<T>() where T : Window
        {
            ServiceProvider.GetRequiredService<T>().ShowDialog();
        }

        public static void ShowWindow()
        {
            ServiceProvider.GetRequiredService<MainView>().ShowDialog();
        }
    }
}
