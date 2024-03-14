using AutoMapper;
using Barbershop.Contracts.Models;
using Barbershop.Services;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;

namespace Barbershop.UI.ViewModels.Pages;

public sealed class OrdersPageViewModel : BaseItemsViewModel<OrderDto>
{
    private readonly OrdersService _ordersService;
    private readonly IMapper _mapper;
    private readonly IWindowDialogService _dialogService;

    public OrdersPageViewModel(OrdersService ordersService, IMapper mapper, IWindowDialogService dialogService)
    {
        _ordersService = ordersService ?? throw new ArgumentNullException(nameof(ordersService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
    }

    public override Task CreateItem()
    {
        throw new NotImplementedException();
    }

    public override Task EditItem()
    {
        throw new NotImplementedException();
    }

    public override Task<IReadOnlyList<OrderDto>> GetItems()
        => _ordersService.GetAll();

    public override IReadOnlyList<string> GetItemSearchProperties(OrderDto order)
    {
        return new List<string>
        {
            order.Barber.ToString(),
            order.Client.ToString(),
            order.BeginDateTime.ToString("d")
        };
    }

    public override Task RemoveItem()
    {
        throw new NotImplementedException();
    }
}
