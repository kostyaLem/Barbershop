namespace Barbershop.Contracts;

public class ServiceSkillLevelDto : EntityDto
{
    public string SkillLevel { get; set; }
    public decimal Cost { get; set; }
    public int MinutesDuration { get; set; }
    public virtual ServiceDto Service { get; set; }
}