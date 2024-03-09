using Barbershop.Contracts.Models;

namespace Barbershop.Contracts.Commands;

public class UpsertOrderCommand
{
    public int Id { get; set; }
    public string OrderStatus { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? CompletedOn { get; set; }
    public int BarbersGain { get; set; }
    public BarberDto Barber { get; set; }
    public ClientDto Client { get; set; }
    public ICollection<ProductDto> Products { get; set; }
    public ICollection<ServiceSkillLevelDto> ServiceSkillLevels { get; set; }
}