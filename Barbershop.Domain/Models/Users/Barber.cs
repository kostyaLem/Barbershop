namespace Barbershop.Domain.Models;

public class Barber : User
{
    public string PasswordHash { get; set; }
    public SkillLevel SkillLevel { get; set; }

    public virtual ICollection<Order> Orders { get; set; }

    public Barber()
    {
        Orders = new HashSet<Order>();
    }
}
