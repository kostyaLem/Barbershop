namespace Barbershop.Domain.Models;

public class Product : Entity
{
    public string Name { get; set; }
    public decimal Cost { get; set; }

    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
}