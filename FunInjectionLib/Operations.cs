using System.Linq;

namespace FunInjectionLib;

internal static class Operations
{
    public static int Zero(int[] operands) => 0;

    public static int Sum(int[] operands) => operands.Sum();

    public static int Add(int[] operands) => Sum(operands);

    public static int Sub(int[] operands) => operands[0] - Sum(operands.Skip(1).ToArray());

    public static int Mult(int[] operands) => operands.Aggregate(1, (c,n) => c * n);

    public static int Avg(int[] operands) => Convert.ToInt32(operands.Average());

    public static int Mean(int[] operands) => Avg(operands);

    public static int Max(int[] operands) => operands.Max();

    public static int Min(int[] operands) => operands.Min();

    public static int Inv(int[] operands) => operands.FirstOrDefault() * -1;

    public static int Incr(int[] operands)
    {
        var value = operands[0];
        return ++value;
    }

    public static int Decr(int[] operands)
    {
        var value = operands[0];
        return --value;
    }
}
