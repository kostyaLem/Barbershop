using Barbershop.Services.Abstractions.Exceptions;
using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.Views;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using HandyControl.Controls;
using System.Windows;
using System.Windows.Input;
using MessageBox = HandyControl.Controls.MessageBox;

namespace Barbershop.UI.ViewModels
{
    /// <summary>
    /// Модель авторизации администратора.
    /// </summary>
    public class AuthViewModel : BaseViewModel
    {
        //private readonly IAuthService _authService;

        public string Login
        {
            get => GetValue<string>(nameof(Login));
            set => SetValue(value, nameof(Login));
        }

        public ICommand LoginCommand { get; }

        public AuthViewModel()
        {
            LoginCommand = new AsyncCommand<object>(TryLogin, x => !string.IsNullOrWhiteSpace(Login));
        }

        public async Task TryLogin(object passwordControl)
        {
            await Execute(async () =>
            {
                await Task.Delay(200);

                try
                {
                    var passwordBox = (PasswordBox)passwordControl;
                    //var admin = await _authService.Login()
                    //App.CurrentUser = admin;
                    Application.Current.MainWindow.Visibility = Visibility.Collapsed;

                    Container.ServiceProvider.GetRequiredService<MainView>().ShowDialog();
                    Application.Current?.Shutdown();
                }
                catch (CredentialsException exc)
                {
                    MessageBox.Error(exc.Message, "Ошибка авторизации");
                }
                catch (AdminNotFoundException exc)
                {
                    MessageBox.Error(exc.Message, "Ошибка авторизации");
                }
                catch (Exception e)
                {
                    MessageBox.Error(e.Message, "Внутренняя ошибка");
                }
            });
        }
    }
}
