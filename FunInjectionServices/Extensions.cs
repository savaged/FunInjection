using System.Collections.Generic;

namespace FunInjectionServices;

public static class Extensions
{
    public static int[] ToInts(this IEnumerable<string> self) =>
        self.Select(s => {
                if (int.TryParse(s, out var i))
                    return i;
                return 0;
                }).Where(i => i != 0).ToArray();
}
