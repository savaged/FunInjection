using System.Reflection;

namespace FunInjectionLib;

internal static class OperationFactory
{
    public delegate int Operation(int[] operands);

    public static Operation Get(string operationName)
    {
        operationName = operationName?.FirstCharToUpper() ?? string.Empty;
        return operationName switch
        {
            nameof(Operations.Sum) => Operations.Sum,
            nameof(Operations.Add) => Operations.Add,
            nameof(Operations.Sub) => Operations.Sub,
            nameof(Operations.Mult) => Operations.Mult,
            nameof(Operations.Avg) => Operations.Avg,
            nameof(Operations.Mean) => Operations.Mean,
            nameof(Operations.Max) => Operations.Max,
            nameof(Operations.Min) => Operations.Min,
            nameof(Operations.Inv) => Operations.Inv,
            nameof(Operations.Incr) => Operations.Incr,
            nameof(Operations.Decr) => Operations.Decr,
            _ => Operations.Zero
        };
    }
}
