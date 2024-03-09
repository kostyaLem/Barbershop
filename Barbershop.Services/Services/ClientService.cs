using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Barbershop.Services.Abstractions;

namespace Barbershop.Services;

public class ClientService : IClientService
{
    private readonly IBaseRepository<Client> _clientRepository;

    private readonly IMapper _mapper;

    public ClientService(IBaseRepository<Client> barberRepo, IMapper mapper)
    {
        _clientRepository = barberRepo ?? throw new ArgumentNullException(nameof(barberRepo));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Create(UpsertClientCommand command)
    {
        var client = _mapper.Map<Client>(command);

        await _clientRepository.Add(client);
    }

    public async Task<IReadOnlyList<ClientDto>> GetAll()
    {
        var clients = await _clientRepository.GetAll();

        return _mapper.Map<IReadOnlyList<ClientDto>>(clients);
    }

    public async Task Update(UpsertClientCommand command)
    {
        await _clientRepository.Update(_mapper.Map<Client>(command));
    }

    public async Task RemoveById(int id)
    {
        await _clientRepository.Remove(id);
    }
}