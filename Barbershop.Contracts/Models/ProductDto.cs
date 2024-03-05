namespace Barbershop.Contracts.Models;

public class ProductDto : EntityDto
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
}