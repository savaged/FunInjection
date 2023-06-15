using FunInjectionLib;

Console.WriteLine(
    OperationService.IsValid(args)
    ? FeedbackService.ForOperation(args[0], OperationService.Run(OperationService.Get(args), args.ToInts()))
    : FeedbackService.USAGE);
