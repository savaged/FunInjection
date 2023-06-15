namespace FunInjectionTests;

public class UnitTests
{
    [Fact]
    public void TestIsValid()
    {
        OperationService.IsValid("sum 2 3 4 1".ToArgs()).Should().BeTrue();
        OperationService.IsValid("sum 2 3 4 x 1".ToArgs()).Should().BeTrue();
        OperationService.IsValid("test 2 3 4".ToArgs()).Should().BeTrue();
        OperationService.IsValid("test".ToArgs()).Should().BeFalse();
        OperationService.IsValid("2 3 4 1 test".ToArgs()).Should().BeFalse();
    }
}
