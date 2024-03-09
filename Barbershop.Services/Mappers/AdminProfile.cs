using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;

namespace Barbershop.Services.Mappers;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<User, AdminDto>();

        CreateMap<Admin, AdminDto>()
            .IncludeMembers(x => x.User);

        CreateMap<AdminDto, UpsertAdminCommand>()
            .ForMember(dest => dest.Password,
                opt => opt.MapFrom((src, dest, _, context) => context.Items[nameof(UpsertAdminCommand.Password)]));
    }
}