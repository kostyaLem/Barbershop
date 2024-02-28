namespace Barbershop.Domain.Models;

public class ServiceSkillLevel : Entity
{
    public SkillLevel SkillLevel { get; set; }
    public decimal Cost { get; set; }
    public int MinutesDuration { get; set; }

    public int ServiceId { get; set; }
    public virtual Service Service { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
}