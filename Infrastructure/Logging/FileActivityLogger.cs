namespace Infrastructure.Logging;

public class FileActivityLogger : IActivityLogger
{
    private readonly string _filePath = "activity.log";

    public async Task LogAsync(string message)
    {
        var logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
        await File.AppendAllTextAsync(_filePath, logLine);
    }
}
