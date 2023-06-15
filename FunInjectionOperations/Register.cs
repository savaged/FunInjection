using FunInjectionAPI;

namespace FunInjectionOperations;

public class Register : IOperations
{
    public Register(IDictionary<string, Func<int[], int>>? registry)
        : this()
    {
        Registry = registry ?? Registry;
    }
    
    public Register()
    {
        Registry = new Dictionary<string, Func<int[], int>>
        {
            { "zero", _ => 0 },
            { "sum", o => o.Sum() },
            { "add", o => o.Sum() },
            { "sub", o => o[0] - o.Skip(1).Sum() },
            { "mult", o => o.Aggregate(1, (c,n) => c * n) },
            { "avg", o => Convert.ToInt32(o.Average()) },
            { "mean", o => Convert.ToInt32(o.Average()) },
            { "max", o => o.Max() },
            { "min", o => o.Min() },
            { "inv", o => o.Select(i => i * -1).Sum() },
            { "incr", o => o.Select(i => ++i).Sum() },
            { "decr", o => o.Select(i => --i).Sum() },
        };
    }

    public IDictionary<string, Func<int[], int>> Registry { get; set; }
}
