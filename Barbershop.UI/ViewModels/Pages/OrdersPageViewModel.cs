using AutoMapper;
using Barbershop.Contracts.Models;
using Barbershop.Services;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.ViewModels.Pages.Edit;
using Barbershop.UI.Views.Pages.Edit;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Barbershop.UI.ViewModels.Pages;

public sealed class OrdersPageViewModel : BaseViewModel
{
    private readonly OrderService _ordersService;

    private readonly IMapper _mapper;
    private readonly IWindowDialogService _dialogService;

    private IReadOnlyList<OrderDto> _orders;

    public ObservableCollection<IGrouping<string, OrderDto>> Orders { get; private set; }
    public int OrdersCount { get; set; }
    public ObservableCollection<SelectableItemModel<BarberDto>> Barbers
    {
        get => GetValue<ObservableCollection<SelectableItemModel<BarberDto>>>(nameof(Barbers));
        set => SetValue(value, nameof(Barbers));
    }
    public ObservableCollection<SelectableItemModel<ClientDto>> Clients { get; private set; }

    public bool SelectAll { get; set; } = true;
    public bool SelectCreated { get; set; }
    public bool SelectCompleted { get; set; }
    public bool SelectCanceled { get; set; }

    public ICommand CompleteOrderCommand { get; }
    public ICommand EditOrderCommand { get; }
    public ICommand CancelOrderCommand { get; }
    public ICommand CreateOrderCommand { get; }

    public ICommand ClearFilterCommand { get; }
    public ICommand FilterOrdersCommand { get; }

    public OrdersPageViewModel(
        OrderService ordersService,
        IMapper mapper,
        IWindowDialogService dialogService)
    {
        _ordersService = ordersService ?? throw new ArgumentNullException(nameof(ordersService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

        LoadViewDataCommand = new AsyncCommand(LoadView);

        CompleteOrderCommand = new AsyncCommand<object>(CompleteOrder);
        EditOrderCommand = new AsyncCommand<object>(EditOrder);
        CancelOrderCommand = new AsyncCommand<object>(CancelOrder);
        CreateOrderCommand = new AsyncCommand(CreateOrder);

        ClearFilterCommand = new AsyncCommand(ClearFilter);
        FilterOrdersCommand = new AsyncCommand(FilterOrders);
    }

    public async Task LoadView()
    {
        await Execute(async () =>
        {
            _orders = await _ordersService.GetAll();
            var groupedOrders = _orders
                .GroupBy(x => x.BeginDateTime.ToString("D"))
                .ToList();
            OrdersCount = _orders.Count;
            Orders = new ObservableCollection<IGrouping<string, OrderDto>>(groupedOrders);

            var barbers = new List<SelectableItemModel<BarberDto>>(_orders.Select(x => new SelectableItemModel<BarberDto>(x.Barber)))
                .DistinctBy(x => x.Value.Id);
            Barbers = new ObservableCollection<SelectableItemModel<BarberDto>>(barbers);

            var clients = new List<SelectableItemModel<ClientDto>>(_orders.Select(x => new SelectableItemModel<ClientDto>(x.Client)))
                .DistinctBy(x => x.Value.Id);
            Clients = new ObservableCollection<SelectableItemModel<ClientDto>>(clients);

            RaisePropertiesChanged();
        });
    }

    private async Task ClearFilter()
    {
        OrdersCount = _orders.Count;
        Orders = new ObservableCollection<IGrouping<string, OrderDto>>(_orders.GroupBy(x => x.BeginDateTime.ToString("D")));
        SelectAll = true;

        var barbers = new List<SelectableItemModel<BarberDto>>(_orders.Select(x => new SelectableItemModel<BarberDto>(x.Barber)))
            .DistinctBy(x => x.Value.Id);
        Barbers = new ObservableCollection<SelectableItemModel<BarberDto>>(barbers);

        var clients = new List<SelectableItemModel<ClientDto>>(_orders.Select(x => new SelectableItemModel<ClientDto>(x.Client)))
            .DistinctBy(x => x.Value.Id);
        Clients = new ObservableCollection<SelectableItemModel<ClientDto>>(clients);

        RaisePropertiesChanged();
    }

    private async Task FilterOrders()
    {
        var selectedBarbers = Barbers.Where(x => x.IsSelected).Select(x => x.Value.Id).ToList();
        var selectedClients = Clients.Where(x => x.IsSelected).Select(x => x.Value.Id).ToList();

        var orders = _orders.Select(x => x);

        if (selectedBarbers.Any())
            orders = orders.Where(x => selectedBarbers.Contains(x.Barber?.Id ?? -1));

        if (selectedClients.Any())
            orders = orders.Where(x => selectedClients.Contains(x.Client?.Id ?? -1));

        if (SelectCanceled)
            orders = orders.Where(x => x.Status == OrderStatusDto.Canceled);
        if (SelectCreated)
            orders = orders.Where(x => x.Status == OrderStatusDto.Created);
        if (SelectCompleted)
            orders = orders.Where(x => x.Status == OrderStatusDto.Done);

        OrdersCount = orders.Count();
        Orders = new ObservableCollection<IGrouping<string, OrderDto>>(orders.GroupBy(x => x.BeginDateTime.ToString("D")));
        RaisePropertiesChanged();
    }

    private async Task CompleteOrder(object obj)
    {
        var orderId = (int)obj;

        await Execute(async () =>
        {
            await _ordersService.CompleteOrder(orderId);
        });
    }

    private async Task EditOrder(object obj)
    {
        var orderId = (int)obj;

        await Execute(async () =>
        {
            var order = await _ordersService.GetById(orderId);

            var vm = new EditOrderViewModel(order);

            if (_dialogService.ShowDialog(typeof(EditOrderPage), vm))
            {

            }
        });
    }

    private async Task CancelOrder(object obj)
    {
        var orderId = (int)obj;

        await Execute(async () =>
        {
            await _ordersService.CancelOrder(orderId);
        });
    }

    private async Task CreateOrder()
    {
        await Execute(async () =>
        {
            var vm = Container.ServiceProvider.GetRequiredService<CreateOrderViewModel>();
            if (_dialogService.ShowDialog(vm))
            {
                await _ordersService.Create(new()
                {
                    CreatedOn = vm.SelectedDate.Value,
                    BarberId = vm.SelectedBarber.Id,
                    ClientId = vm.SelectedClient.Id,
                    ServiceIds = vm.SelectedServices.Select(x => x.Id).ToList()
                });

                await LoadView();
            }
        });
    }
}
