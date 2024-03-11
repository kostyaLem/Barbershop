﻿using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Services;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.ViewModels.Pages.Edit;
using Barbershop.UI.Views.Pages.Edit;
using DevExpress.Mvvm;

namespace Barbershop.UI.ViewModels.Pages;

public sealed class ServicesPageViewModel : BaseItemsViewModel<ServiceDto>
{
    private readonly OfferService _offerService;
    private readonly IMapper _mapper;
    private readonly IWindowDialogService _dialogService;

    public ServicesPageViewModel(OfferService offerService, IMapper mapper, IWindowDialogService dialogService)
    {
        _offerService = offerService ?? throw new ArgumentNullException(nameof(offerService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

        EditItemCommand = new AsyncCommand<object>(EditItem);
        RemoveItemCommand = new AsyncCommand<object>(RemoveItem);
    }

    public override Task CreateItem()
    {
        throw new NotImplementedException();
    }

    public override async Task<IReadOnlyList<ServiceDto>> GetItems()
    {
        var services = await _offerService.GetAll();

        return services;
    }

    public override IReadOnlyList<string> GetItemSearchProperties(ServiceDto service)
    {
        return new List<string>
        {
            service.Name,
            service.JuniorSkill?.Cost.ToString()!,
            service.MiddleSkill?.Cost.ToString()!,
            service.SeniorSkill?.Cost.ToString()!,
        };
    }

    public async Task EditItem(object obj)
    {
        if (obj is int serviceId)
        {
            var currentService = await _offerService.GetById(serviceId);
            var vm = new EditServiceViewModel(currentService);

            if (_dialogService.ShowDialog(typeof(EditServicePage), vm))
            {
                var command = _mapper.Map<UpsertServiceCommand>(vm.Item);
                await _offerService.Update(command);
                await LoadItems();
            }
        }
    }

    public async Task RemoveItem(object obj)
    {
        if (obj is int serviceId)
        {
            await _offerService.RemoveById(serviceId);
        }
    }

    // Скрытие базового метода, для использования своего
    public override Task RemoveItem()
        => throw new NotImplementedException();

    // Скрытие базового метода, для использования своего
    public override Task EditItem()
        => throw new NotImplementedException();
}
