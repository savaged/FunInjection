using FunInjectionAPI;

namespace FunInjectionServices;

public class OperationFactory : IOperationFactory
{
    private readonly IOperations _operations;

    public OperationFactory(IOperations operations)
    {
        _operations = operations ??
            throw new ArgumentNullException(nameof(operations));
    }
    
    public Func<int[], int> Get(string operationName) =>
        _operations.Registry.TryGetValue(operationName?.ToLower() ?? string.Empty, out var value)
            ? value : GetDefault();

    public static Func<int[], int> GetDefault() => _ => 0;
}
