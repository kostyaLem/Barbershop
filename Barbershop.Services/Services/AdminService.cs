using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Barbershop.Services.Abstractions;
using Barbershop.Services.Abstractions.Exceptions;
using Barbershop.Services.Helpers;

namespace Barbershop.Services;

public class AdminService : IAdminService
{
    private readonly IBaseRepository<Admin> _adminRepository;
    private readonly IMapper _mapper;

    public AdminService(IBaseRepository<Admin> adminRepository, IMapper mapper)
    {
        _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Create(CreateAdminCommand command)
    {
        var admin = _mapper.Map<Admin>(command);

        await _adminRepository.Add(admin);
    }

    public async Task<IReadOnlyList<AdminDto>> GetAll()
    {
        var admins = await _adminRepository.GetAll(x => x.User);

        return _mapper.Map<IReadOnlyList<AdminDto>>(admins);
    }

    public async Task RemoveById(int id)
    {
        var adminsCount = await _adminRepository.Count();

        if (adminsCount == 1)
            throw new RemoveAdminException();

        await _adminRepository.Remove(id);
    }
}

public class AuthService
{
    private readonly IBaseRepository<Admin> _adminRepository;
    private readonly IBaseRepository<Barber> _barberRepository;
    private readonly IMapper _mapper;

    public AuthService(
        IBaseRepository<Admin> adminRepository,
        IBaseRepository<Barber> barberRepository,
        IMapper mapper)
    {
        _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
        _barberRepository = barberRepository ?? throw new ArgumentNullException(nameof(barberRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<AuthorizedUserDto> Login(string username, string password, bool isAdmin)
    public async Task<AdminDto> Login(string username, string password)
    {
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(password);

        var passwordHash = HashService.Compute(password);

        var user = await GetUser(username, password, isAdmin);

        if (user == null)
            throw new UserNotFoundException();

        if (user.PasswordHash != passwordHash)
            throw new CredentialsException();

        return user;
    }

    private async Task<AuthorizedUserDto> GetUser(string username, string password, bool isAdmin)
    {
        if (isAdmin)
        {
            var admin = await _adminRepository.FindSingle(x => x.Login == username && x.PasswordHash == password);
            return _mapper.Map<Admin, AuthorizedUserDto>(admin);
        }
    public async Task Create(UpsertAdminCommand command)
    {
        var admin = _mapper.Map<Admin>(command);

        await _adminRepository.Add(admin);
    }

    public async Task<IReadOnlyList<AdminDto>> GetAll()
    {
        var admins = await _adminRepository.GetAll(x => x.User);

        return _mapper.Map<IReadOnlyList<AdminDto>>(admins);
    }

    public async Task Update(UpsertAdminCommand command)
    {
        await _adminRepository.Update(_mapper.Map<Admin>(command));
    }

    public async Task RemoveById(int id)
    {
        var adminsCount = await _adminRepository.Count();

        if (adminsCount == 1)
            throw new RemoveAdminException();

        var barber = await _barberRepository.FindSingle(x => x.Login == username && x.PasswordHash == password);
        return _mapper.Map<Barber, AuthorizedUserDto>(barber);
    }
}