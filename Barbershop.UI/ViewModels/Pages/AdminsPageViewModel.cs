using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Services.Abstractions;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.Views.Pages.Edit;
using DevExpress.Mvvm;
using HandyControl.Controls;
using HandyControl.Tools.Extension;

namespace Barbershop.UI.ViewModels.Pages;

public class AdminsPageViewModel : BaseItemsViewModel<AdminDto>
{
    private readonly IAdminService _adminService;
    private readonly IMapper _mapper;
    private readonly IWindowDialogService _dialogService;

    public AdminsPageViewModel(IAdminService adminService, IMapper mapper, IWindowDialogService dialogService)
    {
        _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

        CreateItemCommand = new AsyncCommand(CreateAdmin);
        EditItemCommand = new AsyncCommand(EditAdmin, SelectedItem != null);
        RemoveItemCommand = new AsyncCommand(RemoveAdmin, SelectedItem != null);

        ItemsView.Filter += CanFilterItem;
    }

    public override Task<IReadOnlyList<AdminDto>> GetItems()
        => _adminService.GetAll();

    private bool CanFilterItem(object obj)
    {
        if (SearchText is { } && obj is AdminDto admin)
        {
            var predicates = new List<string>
            {
                admin.LastName,
                admin.FirstName,
                admin.Email,
                admin.PhoneNumber,
                admin.Username,
                $"{admin.LastName} {admin.FirstName} {admin.Surname}"
            }
            .Where(x => x != null)
            .ToList();

            return predicates.Any(x => x.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
        }

        return true;
    }

    private async Task CreateAdmin()
    {
        await Execute(async () =>
        {
            var vm = new EditAdminViewModel(_dialogService, x => x.Birthday = DateTime.Now.AddYears(-18));

            if (_dialogService.ShowDialog(typeof(EditAdminPage), vm))
            {
                var admin = _mapper.Map<AdminDto, UpsertAdminCommand>(vm.Item,
                    opt => opt.Items[nameof(UpsertAdminCommand.Password)] = (string)vm.Args!);

                await _adminService.Create(admin);
                await LoadItems();
            }
        });
    }

    private async Task EditAdmin()
    {

    }

    private async Task RemoveAdmin()
    {
        if (SelectedItem.Id == App.CurrentUser?.Id)
        {
            MessageBox.Warning($"Невозможно удалить текущего пользователя {App.CurrentUser.Username}");
            return;
        }

        await Execute(async () =>
        {
            await _adminService.RemoveById(SelectedItem.Id);
            await LoadItems();
        });
    }
}