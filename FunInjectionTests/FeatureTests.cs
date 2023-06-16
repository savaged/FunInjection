using FunInjectionOperations;
using Serilog;
using Xunit.Abstractions;

namespace FunInjectionTests;

public class FeatureTests
{
    public FeatureTests(ITestOutputHelper output) =>
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.XunitTestOutput(output)
            .CreateLogger();

    [Fact]
    public void TestSum() =>
        RunOperation("sum 3 2").Should().BeEquivalentTo("sum: 5");

    [Fact]
    public void TestAdd() =>
        RunOperation("add 3 2").Should().BeEquivalentTo("add: 5");

    [Fact]
    public void TestSub() =>
        RunOperation("sub 3 2").Should().BeEquivalentTo("sub: 1");

    [Fact]
    public void TestMult() =>
        RunOperation("mult 3 2").Should().BeEquivalentTo("mult: 6");

    [Fact]
    public void TestAvg() =>
        RunOperation("avg 3 2 3 2 1 2").Should().BeEquivalentTo("avg: 2");

    [Fact]
    public void TestMean() =>
        RunOperation("mean 3 2 3 2 1 2").Should().BeEquivalentTo("mean: 2");

    [Fact]
    public void TestMax() =>
        RunOperation("max 3 2 4 2 1").Should().BeEquivalentTo("max: 4");

    [Fact]
    public void TestMin() =>
        RunOperation("min 3 2 4 2 1").Should().BeEquivalentTo("min: 1");

    [Fact]
    public void TestInv() =>
        RunOperation("inv 3").Should().BeEquivalentTo("inv: -3");

    [Fact]
    public void TestIncr() =>
        RunOperation("incr 3").Should().BeEquivalentTo("incr: 4");

    [Fact]
    public void TestDecr() =>
        RunOperation("decr 3").Should().BeEquivalentTo("decr: 2");


    private static string RunOperation(string command)
    {
        var register = OperationsRegisterLoadService.TryLoadRegister();
        if (register.Registry.Count == 1)
            register = new Register();
        var args = command?.ToArgs() ?? new[] { string.Empty };
        return FeedbackService.ForOperation(
                args[0], OperationService.Run(
                    OperationService.Get(new OperationFactory(register), args), args.ToInts()));
    }
}
