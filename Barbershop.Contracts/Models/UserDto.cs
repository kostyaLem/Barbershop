namespace Barbershop.Contracts.Models;

public class UserDto : EntityDto
{
    public string? LastName { get; set; }
    public string FirstName { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public byte[]? Photo { get; set; }
}