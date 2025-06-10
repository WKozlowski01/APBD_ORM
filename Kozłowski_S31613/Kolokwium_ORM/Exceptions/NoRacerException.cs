namespace Kolokwium_ORM.Exceptions;

public class NoRacerException: Exception
{
    public NoRacerException()
    {
    }

    public NoRacerException(string? message) : base(message)
    {
    }

    public NoRacerException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}