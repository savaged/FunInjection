using System.Collections.Generic;

namespace FunInjectionLib;

public static class Extensions
{
    public static int[] ToInts(this IEnumerable<string> self)
    {
        var list = new List<int>();
        foreach (var s in self)
        {
            if (int.TryParse(s, out var i))
                list.Add(i);
        }
        return list.ToArray();
    }
}
