using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Barbershop.Services.Abstractions;
using Barbershop.Services.Abstractions.Exceptions;

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
        var admin = _mapper.Map<Admin>(command);

        await _adminRepository.Add(admin);
    }

    public async Task Update(UpsertAdminCommand command)
    {
        var admin = _mapper.Map<Admin>(command);

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
}
