namespace Barbershop.Contracts.Models;

public class OrderDto : EntityDto
{
    public BarberDto Barber { get; set; }
    public ClientDto Client { get; set; }

    public List<ServiceSkillLevelDto> Services { get; set; }
    public List<ProductDto> Products { get; set; }

    public DateTime BeginDateTime { get; set; }

    public DateTime EndDateTime 
        => BeginDateTime.AddMinutes(Services.Sum(x => x.MinutesDuration));

    public decimal TotalPrice =>
        Services.Sum(x => x.Cost) + Products.Sum(x => x.Cost);
}