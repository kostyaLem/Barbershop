namespace Barbershop.Contracts.Models;

public class ServiceDto : EntityDto
{
    public string Name { get; set; }

    public ServiceSkillLevelDto? JuniorSkill { get; set; }

    public ServiceSkillLevelDto? MiddleSkill { get; set; }

    public ServiceSkillLevelDto? SeniorSkill { get; set; }
}
