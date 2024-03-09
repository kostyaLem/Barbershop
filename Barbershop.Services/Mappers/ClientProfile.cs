using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;

namespace Barbershop.Services.Mappers;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<User, ClientDto>();

        CreateMap<Client, ClientDto>()
            .IncludeMembers(x => x.User);

        CreateMap<ClientDto, UpsertClientCommand>();
           
    }
}