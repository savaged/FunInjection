namespace FunInjectionLib;

internal static class OperationFactory
{
    public delegate int Operation(params int[] operands);

    public static Operation Get(string operationName)
    {
        operationName = operationName?.FirstCharToUpper() ?? string.Empty;
        switch (operationName)
        {
            case nameof(Operations.Sum):
                return Operations.Sum;
            default:
                return Operations.Zero;
        }
    }
}
