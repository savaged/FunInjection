using System.Linq;

namespace FunInjectionLib;

internal static class Operations
{
    public static int Zero(params int[] operands) => 0;

    public static int Sum(params int[] operands) => operands.Sum();

    public static int Add(params int[] operands) => Sum(operands);

    public static int Sub(params int[] operands) => operands.Aggregate(Sum(operands), (c,n) => c - n);

    public static int Mult(params int[] operands) => operands.Aggregate(1, (c,n) => c * n);

    public static int Avg(params int[] operands) => Convert.ToInt32(operands.Average());

    public static int Mean(params int[] operands) => Avg(operands);

    public static int Max(params int[] operands) => operands.Max();

    public static int Min(params int[] operands) => operands.Min();

    public static int Inv(params int[] operands) => operands.FirstOrDefault() * -1;

    public static int Incr(params int[] operands)
    {
        var value = operands[1];
        return ++value;
    }

    public static int Decr(params int[] operands)
    {
        var value = operands[1];
        return --value;
    }
}
