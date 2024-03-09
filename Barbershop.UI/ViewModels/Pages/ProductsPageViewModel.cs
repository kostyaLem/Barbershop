using AutoMapper;
using Barbershop.Contracts.Models;
using Barbershop.Services.Abstractions;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;

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

    public override Task<IReadOnlyList<ProductDto>> GetItems()
        => _productService.GetAll();

    public override IReadOnlyList<string> GetItemSearchProperties(ProductDto item)
        => new List<string>
        {
            item.Name,
            item.Cost.ToString()
        };
}
