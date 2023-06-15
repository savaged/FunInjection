namespace FunInjectionAPI;

public interface IOperationFactory
{
    Func<int[], int> Get(string operationName);
}