namespace Barbershop.Domain.Models;

public class Admin : Entity
{
    public string PasswordHash { get; set; }

    public User User { get; set; }
}