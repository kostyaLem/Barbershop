using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Services.Abstractions;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.ViewModels.Pages.Edit;
using Barbershop.UI.Views.Pages.Edit;

namespace Barbershop.UI.ViewModels.Pages;

public class ClientsPageViewModel : BaseItemsViewModel<ClientDto>
{
    private readonly IEntityService<ClientDto, Client, UpsertClientCommand> _clientService;
    private readonly IMapper _mapper;
    private readonly IWindowDialogService _dialogService;

    public ClientsPageViewModel(
        IEntityService<ClientDto, Client, UpsertClientCommand> clientService,
        IMapper mapper,
        IWindowDialogService dialogService)
    {
        _clientService = clientService;
        _mapper = mapper;
        _dialogService = dialogService;
    }

    public override async Task CreateItem()
    {
        var vm = new EditClientViewModel(_dialogService);

        if (_dialogService.ShowDialog(typeof(EditClientPage), vm))
        {
            var client = _mapper.Map<ClientDto, UpsertClientCommand>(vm.Item);

            await _clientService.Create(client);
            await LoadItems();
        }
    }

    public override async Task EditItem()
    {
        var currentClient = await _clientService.GetById(SelectedItem.Id);
        var vm = new EditClientViewModel(currentClient, _dialogService);

        if (_dialogService.ShowDialog(typeof(EditClientPage), vm))
        {
            var client = _mapper.Map<ClientDto, UpsertClientCommand>(vm.Item);

            await _clientService.Update(client);
            await LoadItems();
        }
    }

    public override Task<IReadOnlyList<ClientDto>> GetItems()
        => _clientService.GetAll();

    public override IReadOnlyList<string> GetItemSearchProperties(ClientDto item)
        => new List<string>
        {
            item.LastName!,
            item.FirstName,
            item.Email!,
            item.PhoneNumber!,
            item.Notes!,
            $"{item.LastName} {item.FirstName} {item.Surname}"
        };

    public override async Task RemoveItem()
    {
        await _clientService.RemoveById(SelectedItem.Id);
        await LoadItems();
    }
}
