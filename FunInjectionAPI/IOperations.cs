namespace FunInjectionAPI;

public interface IOperations
{
    IDictionary<string, Func<int[], int>> Registry { get; set; }
}
