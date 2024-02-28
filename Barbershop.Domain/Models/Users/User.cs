using Barbershop.Domain.Models.Common;

namespace Barbershop.Domain.Models.Users;

public class User : Entity
{
    public string LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public byte[]? Photo { get; set; }
}
