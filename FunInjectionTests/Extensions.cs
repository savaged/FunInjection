namespace FunInjectionTests;

internal static class Extensions
{
    public static string[] ToArgs(this string self) => self.Split(' ');
}
