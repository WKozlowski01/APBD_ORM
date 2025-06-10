namespace Kolokwium_ORM.Exceptions;

public class NoraceException:Exception
{
    public NoraceException()
    {
    }

    public NoraceException(string? message) : base(message)
    {
    }

    public NoraceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}