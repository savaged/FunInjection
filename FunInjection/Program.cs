using FunInjectionServices;

Console.WriteLine(
    OperationService.IsValid(args)
    ? FeedbackService.ForOperation(args[0], OperationService.Run(
        OperationService.Get(new OperationFactory(
            OperationsRegisterLoadService.TryLoadRegister(
                $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}" +
                "FunInjectionOperations.dll")
            ), args), args.ToInts()))
    : FeedbackService.USAGE);
