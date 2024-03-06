namespace Barbershop.Contracts.Commands
{
    public class CreateAdminCommand
    {
        public string Login { get; }
        public string Password { get; }
        public string? LastName { get; set; }
        public string FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public byte[]? Photo { get; set; }
    }
}
