using AutoMapper;
using Barbershop.Contracts.Models;
using Barbershop.Services;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;

namespace Barbershop.UI.ViewModels.Pages;

public sealed class OrdersPageViewModel : BaseViewModel
{
    private readonly OrderService _ordersService;
    private readonly IMapper _mapper;
    private readonly IWindowDialogService _dialogService;

    public ObservableCollection<IGrouping<string, OrderDto>> Orders { get; private set; }

    public OrdersPageViewModel(OrderService ordersService, IMapper mapper, IWindowDialogService dialogService)
    {
        _ordersService = ordersService ?? throw new ArgumentNullException(nameof(ordersService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

        LoadViewDataCommand = new AsyncCommand(LoadView);
    }

    public async Task LoadView()
    {
        await Execute(async () =>
        {
            var orders = await _ordersService.GetAll();

            var groupedOrders = orders
                .GroupBy(x => x.BeginDateTime.ToString("D"))
                .ToList();

            Orders = new ObservableCollection<IGrouping<string, OrderDto>>(groupedOrders);
            RaisePropertyChanged(nameof(Orders));
        });
    }
}
