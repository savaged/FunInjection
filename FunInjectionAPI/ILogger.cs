namespace FunInjectionAPI;

public interface ILogger
{
    void WriteLine(string msg);
    
    void WriteLine(Exception e);
}