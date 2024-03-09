namespace Barbershop.Contracts.Models;

public class AdminDto : UserDto
{
    public string Username { get; set; }

    public string PasswordHash { get; set; }
}