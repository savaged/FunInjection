using System.Reflection;
using FunInjectionAPI;

namespace FunInjectionServices;

public static class OperationsRegisterLoadService
{
    public static IOperations TryLoadRegister(string operationsRegisterLibraryLocation)
    {
        if (string.IsNullOrEmpty(operationsRegisterLibraryLocation))
            return GetDefaultRegister();
        var operationsAssembly = TryLoadAssembly(operationsRegisterLibraryLocation);
        var registerType = operationsAssembly?.GetTypes()
            .FirstOrDefault(t => t is { IsInterface: false, IsAbstract: false } &&
                                 typeof(IOperations).IsAssignableFrom(t));
        if (registerType != null && Activator.CreateInstance(registerType) is IOperations register)
            return register;
        return GetDefaultRegister();
    }

    private static Assembly? TryLoadAssembly(string operationsRegisterLibraryLocation)
    {
        Assembly? operationsAssembly;
        try
        {
            operationsAssembly = Assembly.LoadFile(operationsRegisterLibraryLocation);
        }
        catch (FileNotFoundException)
        {
            operationsAssembly = null;
        }
        return operationsAssembly;
    }

    private static IOperations GetDefaultRegister() => new ZeroRegister();
    
    private class ZeroRegister : IOperations
    {
        public ZeroRegister() => Registry =
            new Dictionary<string, Func<int[], int>> { { "zero", OperationFactory.GetDefault() } };
        
        public IDictionary<string, Func<int[], int>> Registry { get; set; }
    }
}