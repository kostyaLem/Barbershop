namespace Barbershop.DAL.Exceptions;
public class AlreadyExistsException : Exception
{
    public static void ThrowByPredicate(Func<bool> predicate, string msg)
    {
        if (predicate())
        {
            throw new AlreadyExistsException(msg);
        }
    }

    public AlreadyExistsException()
    {
    }

    public AlreadyExistsException(string message) : base(message)
    {
    }

    public AlreadyExistsException(string message, Exception innerException) : base(message, innerException)
    {
    }
}