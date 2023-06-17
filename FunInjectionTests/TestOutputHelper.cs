using FunInjectionAPI;
using Xunit.Sdk;

namespace FunInjectionTests;

public class OutputHelper : TestOutputHelper, ILogger
{
    public void WriteLine(Exception e) => WriteLine($"{e}", e);
}