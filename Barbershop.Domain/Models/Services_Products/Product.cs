using Barbershop.Domain.Models.Common;

namespace Barbershop.Domain.Models.Services_Products;

public class Product : Entity
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
}