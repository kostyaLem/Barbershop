using Barbershop.Contracts.Models;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using System.ComponentModel;
using System.Windows.Input;
using System.Xml.Linq;

namespace Barbershop.UI.ViewModels.Pages.Edit;

public class EditAdminViewModel : EditViewModel<AdminDto>, INotifyPropertyChanged
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
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

        Item = new AdminDto();
        Title = $"Создание {_viewModelName}";

        preUpdate?.Invoke(Item);

        SelectImageCommand = new DelegateCommand(SelectImage);
        RemoveImageCommand = new DelegateCommand(RemoveImage);

        Args!.MinBirthdayDate = DateTime.Now.AddYears(-18);
        Args!.Password = string.Empty;
    }

    private void SelectImage()
    {
        if (_dialogService.SelectImage(out var imageBytes))
        {
            Item.Photo = imageBytes;
            RaisePropertyChanged(nameof(Item));
        }
    }

    private void RemoveImage()
    {
        Item.Photo = Array.Empty<byte>();
        RaisePropertyChanged(nameof(Item));
    }
}
