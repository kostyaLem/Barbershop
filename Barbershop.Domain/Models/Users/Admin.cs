namespace Barbershop.Domain.Models;

public class Admin : User
{
    public string PasswordHash { get; set; }
}