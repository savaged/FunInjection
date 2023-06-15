namespace FunInjectionLib;

public static class FeedbackService
{
    public const string USAGE =
        "Arguments: operation operand [operand] [operand]\n" +
        "    where the operation is a short name for a math operation like 'mult' (for multiply),\n" +
        "    sum, mean (average), add, sub (subtract), inv (invert), incr (increment) and decr (decrement)\n" +
        "    and each operand is an integer.\n" +
        "    At least one operand and operation are required and two optional further operands.\n" +
        "    E.g. incr 8 or mult 8 9 or sum 8 9 7";

    public static string ForOperation(string operationName, int result) =>
        $"{operationName?.ToLower()}: {result}";
}
