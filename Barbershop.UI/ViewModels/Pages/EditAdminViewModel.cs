﻿using Barbershop.Contracts.Models;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using System.Windows.Input;

namespace Barbershop.UI.ViewModels.Pages
{
    public class EditAdminViewModel : EditViewModel<AdminDto>
    {
        private readonly IWindowDialogService _dialogService;

        public ICommand SelectImageCommand { get; }
        public ICommand RemoveImageCommand { get; }

        public EditAdminViewModel(AdminDto itemViewModel, IWindowDialogService dialogService)
            : this(dialogService)
        {
            Item = itemViewModel;
            Title = $"Редактирование {_viewModelName}";
        }

        public EditAdminViewModel(IWindowDialogService dialogService, Action<AdminDto> preUpdate = null)
        {
            Item = new AdminDto();
            Title = $"Создание {_viewModelName}";

            preUpdate?.Invoke(Item);

            SelectImageCommand = new DelegateCommand(SelectImage);
            RemoveImageCommand = new DelegateCommand(RemoveImage);
        }

        private void SelectImage()
        {
            if (_dialogService.SelectImage(out var imageBytes))
            {
                Item.Photo = imageBytes;
            }
        }

        private void RemoveImage()
        {
            Item.Photo = null;
        }
    }
}
