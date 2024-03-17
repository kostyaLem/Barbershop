using Barbershop.Contracts.Models;
using Barbershop.Services;
using Barbershop.UI.Converters;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace Barbershop.UI.ViewModels.Pages.Edit;

public sealed class CreateOrderViewModel : BaseViewModel
{
    private bool _isLoaded = false;

    private readonly BarberService _barberService;
    private readonly OfferService _offerService;

    private IReadOnlyList<BarberDto> _barbers;

    public int SelectedTabIndex
    {
        get => GetValue<int>(nameof(SelectedTabIndex));
        set => SetValue(value, nameof(SelectedTabIndex));
    }
    public string SearchText
    {
        get => GetValue<string>(nameof(SearchText));
        set => SetValue(value, () => BarbersView.Refresh(), nameof(SearchText));
    }

    public decimal TotalCost
    {
        get => GetValue<decimal>(nameof(TotalCost));
        set => SetValue(value, nameof(TotalCost));
    }
    public int TotalMinutes
    {
        get => GetValue<int>(nameof(TotalMinutes));
        set => SetValue(value, nameof(TotalMinutes));
    }

    public ICollectionView BarbersView { get; set; }
    public IReadOnlyList<TimeSlot> TimeSlots { get; set; }

    public BarberDto SelectedBarber
    {
        get => GetValue<BarberDto>(nameof(SelectedBarber));
        set => SetValue(value, nameof(SelectedBarber));
    }

    public ObservableCollection<ServiceDto> Services { get; set; } = new();
    public ServiceDto ServiceToSelect
    {
        get => GetValue<ServiceDto>(nameof(ServiceToSelect));
        set => SetValue(value, nameof(ServiceToSelect));
    }

    public ObservableCollection<ServiceDto> SelectedServices { get; set; } = new();
    public ServiceDto SelectedService
    {
        get => GetValue<ServiceDto>(nameof(SelectedService));
        set => SetValue(value, nameof(SelectedService));
    }

    public ICommand SelectServiceCommand { get; set; }
    public ICommand RemoveSelectedServiceCommand { get; set; }

    public CreateOrderViewModel(BarberService barberService, OfferService offerService)
    {
        _barberService = barberService;
        _offerService = offerService;

        BarbersView = CollectionViewSource.GetDefaultView(_barbers);

        LoadViewDataCommand = new AsyncCommand(LoadView);

        SelectServiceCommand = new DelegateCommand(SelectService, () => ServiceToSelect != null);
        RemoveSelectedServiceCommand = new DelegateCommand(RemoveSelectedService, () => SelectedService != null);
    }

    private async Task LoadView()
    {
        if (!_isLoaded)
        {
            _barbers = await _barberService.GetAll();
            var _services = await _offerService.GetAll();

            BarbersView = CollectionViewSource.GetDefaultView(_barbers);
            BarbersView.Filter += FilterBarber;

            Services = new ObservableCollection<ServiceDto>(_services);

            RaisePropertiesChanged(nameof(BarbersView), nameof(Services));
            _isLoaded = true;
        }
    }

    private bool FilterBarber(object obj)
    {
        var barber = obj as BarberDto;

        if (string.IsNullOrWhiteSpace(SearchText))
            return true;

        var searchFields = new[]
        {
            barber.LastName,
            barber.FirstName,
            barber.Surname,
            string.Join(' ', barber.LastName, barber.FirstName, barber.Surname)
        };

        return searchFields
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Where(x => x.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
            .Any();
    }

    private void SelectService()
    {
        var selectedServiceSkillLevel = ServiceDtoToServiceConverter.MapService(ServiceToSelect, SelectedBarber.SkillLevel);

        SelectedServices.Add(ServiceToSelect);
        Services.Remove(ServiceToSelect);

        TotalCost += selectedServiceSkillLevel.Cost;
        TotalMinutes += selectedServiceSkillLevel.MinutesDuration;
    }

    private void RemoveSelectedService()
    {
        var selectedServiceSkillLevel = ServiceDtoToServiceConverter.MapService(SelectedService, SelectedBarber.SkillLevel);

        Services.Add(SelectedService);
        SelectedServices.Remove(SelectedService);

        TotalCost -= selectedServiceSkillLevel.Cost;
        TotalMinutes -= selectedServiceSkillLevel.MinutesDuration;
    }

    private void FilterTimeSlots()
    {
        List<OrderDto> ordersAtDay = new();

        for (int i = 0; i < TimeSlots.Count && ordersAtDay.Any(); i++)
        {
            var order = ordersAtDay[0];

            if (order.BeginDateTime.TimeOfDay == TimeSlots[i].Time)
            {
                var servicesDuration = order.Services.Sum(x => x.MinutesDuration);

                var coefficient = (int)Math.Round(servicesDuration / 30.0, MidpointRounding.ToPositiveInfinity);

                if (coefficient == 1)
                {
                    TimeSlots[i].IsBusy = true;
                }
                else
                {
                    for (int j = i; j < coefficient; j++)
                    {
                        TimeSlots[j].IsBusy = true;
                    }

                    i += coefficient;
                }
            }
        }
    }
}

public class TimeSlot : BindableBase
{
    public TimeSpan Time { get; set; }

    public bool IsBusy { get; set; }
}