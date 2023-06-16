using FunInjectionServices;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

Console.WriteLine(
    OperationService.IsValid(args)
    ? FeedbackService.ForOperation(args[0], OperationService.Run(
        OperationService.Get(new OperationFactory(
            OperationsRegisterLoadService.TryLoadRegister(
                $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}" +
                $"OperationsLib{Path.DirectorySeparatorChar}FunInjectionOperations.dll", Log.Logger)
            ), args), args.ToInts()))
    : FeedbackService.USAGE);
