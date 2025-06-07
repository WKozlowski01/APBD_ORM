namespace WebApplication5.Exceptions;

public class ClientDeleteException:Exception
{
    public ClientDeleteException()
    {
    }

    public ClientDeleteException(string? message) : base(message)
    {
    }

    public ClientDeleteException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
