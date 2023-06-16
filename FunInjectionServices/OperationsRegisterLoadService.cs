using System.Reflection;
using FunInjectionAPI;
using Serilog;

namespace FunInjectionServices;

public static class OperationsRegisterLoadService
{
    private static ILogger? _logger;
    
    public static IOperations TryLoadRegister(
        string operationsRegisterLibraryLocation = "",
        ILogger? logger = null)
    {
        _logger ??= logger;
        var assembly = GetOperationsLib();
        if (!string.IsNullOrEmpty(operationsRegisterLibraryLocation))
            assembly = TryLoadAssembly(operationsRegisterLibraryLocation) ?? assembly;
        var registerType = GetIOperationsType(assembly);
        if (registerType is not null
            && Activator.CreateInstance(registerType) is IOperations register)
            return register;
        return GetDefaultRegister();
    }

    private static Assembly? GetOperationsLib() =>
        AppDomain.CurrentDomain.GetAssemblies()
            .FirstOrDefault(a => GetIOperationsType(a) is not null);

    private static Type? GetIOperationsType(Assembly? assembly) =>
        assembly?.GetTypes().Where(
            t => t is { IsInterface: false, IsAbstract: false }
                 && typeof(IOperations).IsAssignableFrom(t))
            .FirstOrDefault(t => t != typeof(ZeroRegister));

    private static Assembly? TryLoadAssembly(string operationsRegisterLibraryLocation)
    {
        Assembly? value;
        try
        {
            value = Assembly.LoadFile(operationsRegisterLibraryLocation);
        }
        catch (FileNotFoundException e)
        {
            _logger?.Error(e, "It must be you!");
            value = null;
        }
        return value;
    }

    private static IOperations GetDefaultRegister() => new ZeroRegister();

    private class ZeroRegister : IOperations
    {
        public ZeroRegister() => Registry =
            new Dictionary<string, Func<int[], int>> { { "zero", OperationFactory.GetDefault() } };

        public IDictionary<string, Func<int[], int>> Registry { get; set; }
    }
}
