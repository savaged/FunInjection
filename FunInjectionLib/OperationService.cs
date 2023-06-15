using System.Text.RegularExpressions;

namespace FunInjectionLib;

public static class OperationService
{
    public static bool IsValid(string[] args) =>
        args.Length > 1 && Regex.IsMatch(args[0], "[a-z]{3,}");
    
    public static Func<int[], int> Get(string[] args) => OperationFactory.Get(args[0]);
    
    public static int Run(Func<int[], int> operation, int[] operands) => operation(operands);
}
