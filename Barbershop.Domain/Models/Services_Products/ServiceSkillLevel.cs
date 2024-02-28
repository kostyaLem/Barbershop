using Barbershop.Domain.Models.Common;
using Barbershop.Domain.Models.Services;

namespace Barbershop.Domain.Models.Services_Products;

public class ServiceSkillLevel : Entity
{
    public SkillLevel SkillLevel { get; set; }
    public decimal Cost { get; set; }
    public int MinutesDuration { get; set; }
    public int ServiceId { get; set; }
    public virtual Service Service { get; set; }
}