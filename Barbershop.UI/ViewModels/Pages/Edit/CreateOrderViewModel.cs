using Barbershop.Contracts.Models;
using Barbershop.Services;
using Barbershop.UI.ViewModels.Base;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using HandyControl.Collections;
using HandyControl.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Barbershop.UI.ViewModels.Pages.Edit;

public sealed class CreateOrderViewModel : BaseViewModel
{
    private readonly BarberService _barberService;
    private readonly OfferService _offerService;

    private IReadOnlyList<BarberDto> _barbers;
    private IReadOnlyList<ServiceDto> _services;

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
    public ICollectionView ServicesView { get; set; }

    public BarberDto SelectedBarber
    {
        get => GetValue<BarberDto>(nameof(SelectedBarber));
        set => SetValue(value, nameof(SelectedBarber));
    }

    public ICommand LoadViewDataCommand { get; set; }
    public ICommand SelectedServicesChangedCommand { get; set; }

    public CreateOrderViewModel(BarberService barberService, OfferService offerService)
    {
        _barberService = barberService;
        _offerService = offerService;

        BarbersView = CollectionViewSource.GetDefaultView(_barbers);
        ServicesView = CollectionViewSource.GetDefaultView(_services);

        LoadViewDataCommand = new AsyncCommand(LoadView);
        SelectedServicesChangedCommand = new DelegateCommand<ManualObservableCollection<ServiceDto>>(SelectedServicesChanged);
    }

    private void SelectedServicesChanged(ManualObservableCollection<ServiceDto> serviceDtos)
    {
        var selectedServices = serviceDtos.Select(service =>
        {
            return SelectedBarber.SkillLevel switch
            {
                BarberSkillLevel.Junior => service.JuniorSkill,
                BarberSkillLevel.Middle => service.MiddleSkill,
                BarberSkillLevel.Senior => service.SeniorSkill
            };
        });

        TotalCost = selectedServices.Sum(x => x.Cost);
        TotalMinutes = selectedServices.Sum(x => x.MinutesDuration);
    }

    private async Task LoadView()
    {
        _barbers = await _barberService.GetAll();
        _services = await _offerService.GetAll();

        BarbersView = CollectionViewSource.GetDefaultView(_barbers);
        BarbersView.Filter += FilterBarber;
        ServicesView = CollectionViewSource.GetDefaultView(_services);

        RaisePropertiesChanged(nameof(BarbersView), nameof(ServicesView));
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

        return searchFields.Where(x => !string.IsNullOrWhiteSpace(x)).Contains(SearchText);
    }
}
