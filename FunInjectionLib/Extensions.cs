using System.Collections.Generic;

namespace FunInjectionLib;

public static class Extensions
{
    public static string FirstCharToUpper(this string self) =>
        $"{self.First().ToString().ToUpper()}{self[1..]}";

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
