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
    
    public Func<int[], int> Get(string operationName)
    {
        operationName = operationName?.ToLower() ?? string.Empty;
        return _operations.Registry.TryGetValue(operationName, out var value)
            ? value : GetDefault();
    }

    internal static Func<int[], int> GetDefault() => o => 0;
}
