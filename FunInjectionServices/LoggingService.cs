using FunInjectionAPI;

namespace FunInjectionServices;

public class LoggingService : ILogger
{
    private readonly Action<string> _writer;

    public LoggingService(Action<string> writer) =>
        _writer = writer ?? throw new ArgumentNullException(nameof(writer));
    
    public void WriteLine(string msg) => _writer(msg);

    public void WriteLine(Exception e) => _writer(e.ToString());
}