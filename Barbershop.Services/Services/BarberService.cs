using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Barbershop.Services.Abstractions;
using Barbershop.Services.Abstractions.Exceptions;
using Barbershop.Services.Helpers;

namespace Barbershop.Services;

public class BarberService : IBarberService
{
    private readonly IBaseRepository<Barber> _barberRepository;
    private readonly IMapper _mapper;

    public BarberService(IBaseRepository<Barber> barberRepository, IMapper mapper)
    {
        _barberRepository = barberRepository ?? throw new ArgumentNullException(nameof(barberRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Create(CreateBarberCommand command)
    {
        var barber = _mapper.Map<Barber>(command);

        await _barberRepository.Add(barber);
    }

    public async Task<IReadOnlyList<BarberDto>> GetAll()
    {
        var barbers = await _barberRepository.GetAll(x => x.User);

        return _mapper.Map<IReadOnlyList<BarberDto>>(barbers);
    }

    public async Task<BarberDto> Login(string username, string password)
    {
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(password);

        var passwordHash = HashService.Compute(password);

        var barber = await _barberRepository.FindSingle(x => x.Login == username, x => x.User);

        if (barber == null)
            throw new UserNotFoundException();

        if (barber.PasswordHash != passwordHash)
            throw new CredentialsException();

        return _mapper.Map<BarberDto>(barber);
    }

    public async Task RemoveById(int id)
    {
        await _barberRepository.Remove(id);
    }
}