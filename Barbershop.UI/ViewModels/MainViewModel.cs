using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using HandyControl.Themes;
using HandyControl.Tools;
using System.Windows;
using System.Windows.Input;

namespace Barbershop.UI.ViewModels
{
    /// <summary>
    /// Модель главного окна приложения.
    /// </summary>
    public class MainViewModel : BaseItemsViewModel<int>
    {

        public ICommand ChangeThemeCommand { get; }

        public MainViewModel()
        {
            ChangeThemeCommand = new DelegateCommand<ApplicationTheme>(ChangeTheme);
        }

        private void ChangeTheme(ApplicationTheme selectedTheme)
        {
            if (selectedTheme == ThemeManager.Current.ApplicationTheme)
                return;

            ThemeAnimationHelper.AnimateTheme(Application.Current.MainWindow, ThemeAnimationHelper.SlideDirection.Top, 0.3, 1, 0.5);
            ThemeManager.Current.ApplicationTheme = selectedTheme;
            ThemeAnimationHelper.AnimateTheme(Application.Current.MainWindow, ThemeAnimationHelper.SlideDirection.Bottom, 0.3, 0.5, 1);
        }
    }
}
