namespace Barbershop.Contracts.Commands;

public class UpsertProductCommand
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
}