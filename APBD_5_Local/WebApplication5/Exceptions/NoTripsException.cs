namespace WebApplication5.Exceptions;

public class NoTripsException: Exception
{
    public NoTripsException()
    {
    }

    public NoTripsException(string? message) : base(message)
    {
    }

    public NoTripsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}