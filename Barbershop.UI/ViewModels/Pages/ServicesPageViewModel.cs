using AutoMapper;
using Barbershop.Contracts.Models;
using Barbershop.Services;
using Barbershop.UI.ViewModels.Base;

namespace Barbershop.UI.ViewModels.Pages;

public sealed class ServicesPageViewModel : BaseItemsViewModel<ServiceDto>
{
    private readonly OfferService _offerService;
    private readonly IMapper _mapper;

    public ServicesPageViewModel(OfferService offerService, IMapper mapper)
    {
        _offerService = offerService ?? throw new ArgumentNullException(nameof(offerService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public override Task CreateItem()
    {
        throw new NotImplementedException();
    }

    public override Task EditItem()
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

    public override Task RemoveItem()
    {
        throw new NotImplementedException();
    }
}
