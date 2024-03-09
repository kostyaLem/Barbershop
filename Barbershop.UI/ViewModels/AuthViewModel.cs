﻿using Barbershop.Services.Abstractions;
using Barbershop.Services.Abstractions.Exceptions;
using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.Views;
using DevExpress.Mvvm;
using HandyControl.Controls;
using System.Windows;
using System.Windows.Input;
using MessageBox = HandyControl.Controls.MessageBox;

namespace Barbershop.UI.ViewModels;

/// <summary>
/// Модель авторизации администратора.
/// </summary>
public class AuthViewModel : BaseViewModel
{
    private readonly IAdminService _adminService;

    public string Login
    {
        get => GetValue<string>(nameof(Login));
        set => SetValue(value, nameof(Login));
    }

    public ICommand LoginCommand { get; }

    public AuthViewModel(IAdminService adminService)
    {
        _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));

        LoginCommand = new AsyncCommand<object>(TryLogin, x => !string.IsNullOrWhiteSpace(Login));
    }

    public async Task TryLogin(object passwordControl)
    {
        var passwordBox = (PasswordBox)passwordControl;

        if (string.IsNullOrWhiteSpace(passwordBox.Password))
        {
            MessageBox.Warning("Заполните пароль.");
            return;
        }

        await Execute(async () =>
        {
            await Task.Delay(200);

            try
            {
                var admin = await _adminService.Login(Login, passwordBox.Password);
                App.CurrentUser = admin;
                Application.Current.MainWindow.Visibility = Visibility.Collapsed;

                Container.ShowView<MainView>();

                Application.Current?.Shutdown();
            }
            catch (CredentialsException exc)
            {
                MessageBox.Error(exc.Message, "Ошибка авторизации");
            }
            catch (UserNotFoundException exc)
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
