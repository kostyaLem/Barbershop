using AutoMapper;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;

namespace Barbershop.Services.Mappers;

public sealed class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Service, ServiceDto>()
            .ForMember(dest => dest.JuniorSkill, opt => opt.MapFrom((src, _, dest) =>
            {
                var service = src.ServiceSkillLevels
                    .SingleOrDefault(x => x.SkillLevel == SkillLevel.Junior);

                if (service != null)
                {
                    return new ServiceSkillLevelDto
                    {
                        Cost = service.Cost,
                        MinutesDuration = service.MinutesDuration
                    };
                }

                return default;
            }))
            .ForMember(dest => dest.MiddleSkill, opt => opt.MapFrom((src, _, dest) =>
            {
                var service = src.ServiceSkillLevels
                    .SingleOrDefault(x => x.SkillLevel == SkillLevel.Middle);

                if (service != null)
                {
                    return new ServiceSkillLevelDto
                    {
                        Cost = service.Cost,
                        MinutesDuration = service.MinutesDuration
                    };
                }

                return default;
            }))
            .ForMember(dest => dest.SeniorSkill, opt => opt.MapFrom((src, _, dest) =>
            {
                var service = src.ServiceSkillLevels
                    .SingleOrDefault(x => x.SkillLevel == SkillLevel.Senior);

                if (service != null)
                {
                    return new ServiceSkillLevelDto
                    {
                        Cost = service.Cost,
                        MinutesDuration = service.MinutesDuration
                    };
                }

                return default;
            }));
    }
}