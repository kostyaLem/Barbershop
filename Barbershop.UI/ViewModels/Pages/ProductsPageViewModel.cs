﻿using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Services.Abstractions;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.Views.Pages.Edit;

namespace Barbershop.UI.ViewModels.Pages;

public class ProductsPageViewModel : BaseItemsViewModel<ProductDto>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    private readonly IWindowDialogService _dialogService;

    public ProductsPageViewModel(
        IProductService productService,
        IMapper mapper,
        IWindowDialogService dialogService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
    }

    public override async Task CreateItem()
    {
        var vm = new EditViewModel<ProductDto>();

        if (_dialogService.ShowDialog(typeof(EditProductPage), vm))
        {
            var command = _mapper.Map<UpsertProductCommand>(vm.Item);
            await _productService.Create(command);
            await LoadItems();
        }
    }

    public override Task EditItem()
    {
        throw new NotImplementedException();
    }

    public override async Task RemoveItem()
    {
        await _productService.RemoveById(SelectedItem.Id);
        await LoadItems();
    }

    public override Task<IReadOnlyList<ProductDto>> GetItems()
        => _productService.GetAll();

    public override IReadOnlyList<string> GetItemSearchProperties(ProductDto item)
        => new List<string>
        {
            item.Name,
            item.Cost.ToString()
        };
}