using FunInjectionLib;

Console.WriteLine(
    OperationService.IsValid(args)
    ? Feedback.ForOperation(args[0], OperationService.Run(OperationService.Get(args), args.ToInts()))
    : Feedback.USAGE);
