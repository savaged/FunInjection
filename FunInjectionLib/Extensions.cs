using System.Collections.Generic;

namespace FunInjectionLib;

internal static class Extensions
{
    public static string FirstCharToUpper(this string self) =>
        self is not null ? $"{self.First().ToString().ToUpper()}{self.Substring(1)}" : string.Empty;

    public static int[] ToInts(this string[] self)
    {
        var list = new List<int>();
        if (self is not null)
            foreach (var s in self)
            {
                if (Int32.TryParse(s, out int i))
                    list.Add(i);
            }
        return list.ToArray();
    }
}
