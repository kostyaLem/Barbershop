namespace Barbershop.Services.Abstractions.Exceptions
{
    public class AdminNotFoundException : Exception
    {
        public AdminNotFoundException()
            : base("Пользователь с таким логином и паролем не существует.")
        {
        }
    }
}
