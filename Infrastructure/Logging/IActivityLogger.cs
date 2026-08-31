namespace Infrastructure.Logging;

public interface IActivityLogger
{
    Task LogAsync(string message);
}
