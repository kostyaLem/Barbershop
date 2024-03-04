namespace Barbershop.Contracts;

public class AdminDto : UserDto
{
    public string PasswordHash { get; set; }
}