using System.Reflection;

namespace FunInjectionLib;

internal static class OperationFactory
{
    public static Func<int[], int> Get(string operationName)
    {
        operationName = operationName?.ToLower() ?? string.Empty;
        if (!Operations.Registry.ContainsKey(operationName))
            return Operations.Registry["zero"];
        return Operations.Registry[operationName];
    }
}
