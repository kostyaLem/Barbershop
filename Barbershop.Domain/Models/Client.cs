namespace Barbershop.Domain.Models;

public class Client : Entity
{
    public string Notes { get; set; }

    public virtual ICollection<Order> Orders { get; set; }

    public User User { get; set; }

    public Client()
    {
        Orders = new HashSet<Order>();
    }
}