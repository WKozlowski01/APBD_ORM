namespace WebApplication5.Exceptions;

public class NoClientException:Exception
{
    public NoClientException()
    {
    }

    public NoClientException(string? message) : base(message)
    {
    }

    public NoClientException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}