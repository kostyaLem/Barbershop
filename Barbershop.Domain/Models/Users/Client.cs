namespace Barbershop.Domain.Models;

public class Client : User
{
    public string Notes { get; set; }

    public virtual ICollection<Order> Orders { get; set; }

    public Client()
    {
        Orders = new HashSet<Order>();
    }
}