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

    public async Task Create(UpsertAdminCommand command)
    {
        command.Password = HashService.Compute(command.Password);
        var admin = _mapper.Map<Admin>(command);

        await _adminRepository.Add(admin);
    }

    public async Task Update(UpsertAdminCommand command)
    {
        var admin = _mapper.Map<Admin>(command);

        if (string.IsNullOrEmpty(admin.PasswordHash))
        {
            admin.PasswordHash = (await _adminRepository.GetById(admin.Id)).PasswordHash;
        }
        else
        {
            admin.PasswordHash = HashService.Compute(command.Password);
        }

        await _adminRepository.Update(admin);
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

    public async Task<AdminDto> GetById(int id)
    {
        var admin = await _adminRepository.GetById(id, x => x.User);

        return _mapper.Map<AdminDto>(admin);
    }
}
