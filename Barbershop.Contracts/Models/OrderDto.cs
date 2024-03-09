namespace Barbershop.Contracts.Models;

public class OrderDto : EntityDto
{
    public string OrderStatus { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? CompletedOn { get; set; }
    public int BarbersGain { get; set; }
    public BarberDto Barber { get; set; }
    public ClientDto Client { get; set; }
    public ICollection<ProductDto> Products { get; set; }
    public ICollection<ServiceSkillLevelDto> ServiceSkillLevels { get; set; }
}