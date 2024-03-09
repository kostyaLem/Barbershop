namespace Barbershop.Contracts.Models;

public class AuthorizedUserDto : EntityDto
{
    public string Username { get; set; }
    public bool IsAdmin { get; set; }
    public string PasswordHash { get; set; }
}