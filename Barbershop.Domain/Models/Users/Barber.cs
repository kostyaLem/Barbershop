using Barbershop.Domain.Models.Common;
using Barbershop.Domain.Models.Services_Products;

namespace Barbershop.Domain.Models.Users;

public class Barber : User
{
    public string Password { get; set; }

    public SkillLevel SkillLevel { get; set; }

    public virtual ICollection<Order> Orders { get; set; }

    public Barber()
    {
        Orders = new HashSet<Order>();
    }
}
