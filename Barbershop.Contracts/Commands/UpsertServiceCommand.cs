namespace Barbershop.Contracts.Commands;

public class UpsertServiceCommand : IdentifiedCommand
{
    public string Name { get; set; }
}