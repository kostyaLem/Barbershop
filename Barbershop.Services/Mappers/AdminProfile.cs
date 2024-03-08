using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;

namespace Barbershop.Services.Mappers
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminDto>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.User.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.User.Photo))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.User.Birthday))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Login))
                .ReverseMap();

            CreateMap<AdminDto, CreateAdminCommand>()
                .ForMember(dest => dest.Password,
                    opt => opt.MapFrom((src, dest, _, context) => context.Items[nameof(CreateAdminCommand.Password)]));
        }
    }
}
