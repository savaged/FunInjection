using System.Linq;

namespace FunInjectionLib;

internal static class Operations
{
    public static int Zero(params int[] operands) => 0;

    public static int Sum(params int[] operands) => operands?.Sum() ?? 0;
}
