using System.Text.RegularExpressions;
using FunInjectionAPI;

namespace FunInjectionServices;

public static class OperationService
{
    public static bool IsValid(string[] args) =>
        args.Length > 1 && Regex.IsMatch(args[0], "[a-z]{3,}");

    public static Func<int[], int> Get(IOperationFactory operationFactory, string[] args) =>
        operationFactory?.Get(args[0]) ?? OperationFactory.GetDefault();

    public static int Run(Func<int[], int> operation, int[] operands) => operation(operands);
}
