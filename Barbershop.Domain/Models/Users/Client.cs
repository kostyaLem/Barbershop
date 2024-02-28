using Barbershop.Domain.Models.Services_Products;

namespace Barbershop.Domain.Models.Users;

public class Client : User
{
    public virtual ICollection<Order> Orders { get; set; }

    public string Notes { get; set; }

    public Client()
    {
            Orders = new HashSet<Order>();
    }
}