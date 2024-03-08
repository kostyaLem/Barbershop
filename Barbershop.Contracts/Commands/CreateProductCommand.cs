namespace Barbershop.Contracts.Commands;

public class CreateProductCommand
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
}