namespace Kolokwium_ORM.Exceptions;

public class NoTrackExcepion:Exception
{
    public NoTrackExcepion()
    {
    }

    public NoTrackExcepion(string? message) : base(message)
    {
    }

    public NoTrackExcepion(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}