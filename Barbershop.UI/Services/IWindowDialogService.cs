﻿using Barbershop.UI.ViewModels.Base;

namespace Barbershop.UI.Services
{
    /// <summary>
    /// Интерфейс управления диалоговым окном.
    /// </summary>
    internal interface IWindowDialogService
    {
        bool ShowDialog(Type controlType, BaseViewModel dataContext);
        bool SelectImage(out byte[] imageBytes);
    }
}