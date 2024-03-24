using Barbershop.Contracts.Models;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Barbershop.UI.ViewModels.Pages.Edit;

public class EditOrderViewModel : EditViewModel<OrderDto>
{
    public ObservableCollection<ProductDto> ProductsToSelect { get; set; } = new();
    public ProductDto ProductToSelect
    {
        get => GetValue<ProductDto>(nameof(ProductToSelect));
        set => SetValue(value, nameof(ProductToSelect));
    }

    public ObservableCollection<ProductDto> SelectedProducts { get; set; } = new();
    public ProductDto SelectedProduct
    {
        get => GetValue<ProductDto>(nameof(SelectedProduct));
        set => SetValue(value, nameof(SelectedProduct));
    }


    public ICommand AddProductCommand { get; }
    public ICommand RemoveProductCommand { get; }

    public EditOrderViewModel(OrderDto order)
        : base(order)
    {
        AddProductCommand = new DelegateCommand(SelectProduct, () => ProductToSelect != null);
        RemoveProductCommand = new DelegateCommand(RemoveProduct, () => SelectedProduct != null);
    }

    private void SelectProduct()
    {
        SelectedProducts.Add(ProductToSelect);
        ProductsToSelect.Remove(ProductToSelect);
    }

    private void RemoveProduct()
    {
        ProductsToSelect.Add(SelectedProduct);
        SelectedProducts.Remove(SelectedProduct);
    }
}

public class EditAdminViewModel : EditViewModel<AdminDto>
{
    private readonly IWindowDialogService _dialogService;

    public ICommand SelectImageCommand { get; }
    public ICommand RemoveImageCommand { get; }

    public EditAdminViewModel(AdminDto itemViewModel, IWindowDialogService dialogService)
        : this(dialogService)
    {
        Item = itemViewModel;
    }

    public EditAdminViewModel(IWindowDialogService dialogService, Action<AdminDto> preUpdate = null)
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
