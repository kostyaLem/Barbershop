using Barbershop.Contracts;
using Barbershop.Contracts.Models;
using System.Windows;

namespace Barbershop.UI
{
    public partial class App : Application
    {
        public static AdminDto CurrentUser { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Container.ShowWindow();
        }
    }
}
