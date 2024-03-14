namespace Barbershop.Contracts.Models;

public class BarberDto : UserDto
{
    public string Login { get; set; }
    public string PasswordHash { get; set; }

    public string SkillLevel { get; set; }

    public virtual ICollection<OrderDto> Orders { get; set; }

    public override string ToString()
        => string.Join(' ', LastName, FirstName, Surname);
}