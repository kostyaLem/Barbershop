using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Barbershop.Services.Abstractions;

namespace Barbershop.Services;

public class ServiceService : IServiceService
{
    private readonly IBaseRepository<Service> _serviceRepository;
    private readonly IMapper _mapper;

    public ServiceService(IBaseRepository<Service> serviceRepo, IMapper mapper)
    {
        _serviceRepository = serviceRepo ?? throw new ArgumentNullException(nameof(serviceRepo));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Create(UpsertServiceCommand command)
    {
        var service = _mapper.Map<Service>(command);

        await _serviceRepository.Add(service);
    }

    public async Task<IReadOnlyList<ServiceDto>> GetAll()
    {
        var services = await _serviceRepository.GetAll();

        return _mapper.Map<IReadOnlyList<ServiceDto>>(services);
    }

    public async Task Update(UpsertServiceCommand command)
    {
        await _serviceRepository.Update(_mapper.Map<Service>(command));
    }

    public async Task RemoveById(int id)
    {
        await _serviceRepository.Remove(id);
    }
}