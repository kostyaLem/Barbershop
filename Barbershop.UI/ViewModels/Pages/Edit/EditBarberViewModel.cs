using Barbershop.Contracts.Models;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using System.Windows.Input;

namespace Barbershop.UI.ViewModels.Pages.Edit;

public class EditBarberViewModel : EditViewModel<BarberDto>
{
    private readonly IWindowDialogService _dialogService;

    public ICommand SelectImageCommand { get; }
    public ICommand RemoveImageCommand { get; }

    public EditBarberViewModel(BarberDto itemViewModel, IWindowDialogService dialogService)
        : this(dialogService)
    {
        Item = itemViewModel;
        Title = $"Редактирование {_viewModelName}";
    }

    public EditBarberViewModel(IWindowDialogService dialogService, Action<BarberDto> preUpdate = null)
        : base(preUpdate)
    {
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

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
