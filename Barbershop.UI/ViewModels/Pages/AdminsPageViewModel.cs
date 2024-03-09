using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Services.Abstractions;
using Barbershop.UI.Services;
using Barbershop.UI.ViewModels.Base;
using Barbershop.UI.Views.Pages.Edit;
using DevExpress.Mvvm;
using HandyControl.Controls;

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
        //EditItemCommand = new AsyncCommand(EditAdmin, SelectedItem != null);
        RemoveItemCommand = new AsyncCommand(RemoveAdmin, SelectedItem != null);
    }

    public override Task<IReadOnlyList<AdminDto>> GetItems()
        => _adminService.GetAll();

    public override IReadOnlyList<string> GetItemSearchProperties(AdminDto item)
        => new List<string>
        {
            item.LastName!,
            item.FirstName,
            item.Email!,
            item.PhoneNumber!,
            item.Username,
            $"{item.LastName} {item.FirstName} {item.Surname}"
        };

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