namespace Barbershop.Contracts.Models;

public class BarberDto : UserDto
{
    public string PasswordHash { get; set; }

    public string SkillLevel { get; set; }

    public virtual ICollection<OrderDto> Orders { get; set; }
}