using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Barbershop.Services.Abstractions;
using Barbershop.Services.Abstractions.Exceptions;
using Barbershop.Services.Helpers;

namespace Barbershop.Services
{
    /// <summary>
    /// Сервис управления администраторами.
    /// </summary>
    internal class AdminService : IAdminService
    {
        private readonly IBaseRepository<Admin> _adminRepository;
        private readonly IMapper _mapper;

        public AdminService(IBaseRepository<Admin> adminRepo, IMapper mapper)
        {
            _adminRepository = adminRepo ?? throw new ArgumentNullException(nameof(adminRepo));
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

        public async Task<AdminDto> Login(string username, string password)
        {
            ArgumentNullException.ThrowIfNull(username);
            ArgumentNullException.ThrowIfNull(password);

            var passwordHash = HashService.Compute(password);

            var admin = await _adminRepository.FindSingle(x => x.Login == username, x => x.User);

            if (admin == null)
                throw new AdminNotFoundException();

            if (admin.PasswordHash != passwordHash)
                throw new CredentialsException();

            return _mapper.Map<AdminDto>(admin);
        }

        public async Task RemoveById(int id)
        {
            var adminsCount = await _adminRepository.Count();

            if (adminsCount == 1)
                throw new RemoveAdminException();

            await _adminRepository.Remove(id);
        }
    }
}
