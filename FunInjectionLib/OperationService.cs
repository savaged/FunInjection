using System.Text.RegularExpressions;

namespace FunInjectionLib;

public static class OperationService
{
    public static int TryOperation(string[] args)
    {
        if (!IsValidOperation(args))
            return 0;
        return TryOperation(args[0], args.ToInts());
    }

    public static bool IsValidOperation(string[] args) =>
        args is not null && args.Length > 1 && Regex.IsMatch(args[0], "[a-z]{3,}");

    private static int TryOperation(string operationName, params int[] operands) =>
        OperationFactory.Get(operationName)(operands);

}
