using System.Windows;

namespace Barbershop.UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Container.ShowWindow();
        }
    }
}
