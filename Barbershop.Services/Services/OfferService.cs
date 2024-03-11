using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;

namespace Barbershop.Services;

public sealed class OfferService : EntityService<ServiceDto, Service, UpsertServiceCommand>
{
    public OfferService(IBaseRepository<Service> repository, IMapper mapper)
        : base(repository, mapper)
    {
    }

    public override async Task<IReadOnlyList<ServiceDto>> GetAll()
    {
        var services = await _entityRepository.GetAll(x => x.ServiceSkillLevels);

        return _mapper.Map<IReadOnlyList<ServiceDto>>(services);
    }
}