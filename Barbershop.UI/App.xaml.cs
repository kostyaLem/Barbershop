using Barbershop.Contracts.Models;
using DevExpress.Mvvm;
using HandyControl.Themes;
using HandyControl.Tools;
using System.Windows;
using System.Windows.Input;

namespace Barbershop.UI
{
    public partial class App : Application
    {
        public static AdminDto CurrentUser { get; set; }

        public static ICommand ChangeThemeCommand { get; }

        static App()
        {
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;

            ChangeThemeCommand = new DelegateCommand<ApplicationTheme>(ChangeTheme);
        }

        private static void ChangeTheme(ApplicationTheme selectedTheme)
        {
            if (selectedTheme == ThemeManager.Current.ApplicationTheme)
                return;

            ThemeAnimationHelper.AnimateTheme(Application.Current.MainWindow, ThemeAnimationHelper.SlideDirection.Top, 0.3, 1, 0.5);
            ThemeManager.Current.ApplicationTheme = selectedTheme;
            ThemeAnimationHelper.AnimateTheme(Application.Current.MainWindow, ThemeAnimationHelper.SlideDirection.Bottom, 0.3, 0.5, 1);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Container.PrepareApp();
            Container.ShowWindow();
        }
    }
}
