using FunInjectionOperations;
using FunInjectionServices;

Console.WriteLine(
    OperationService.IsValid(args)
    ? FeedbackService.ForOperation(args[0], OperationService.Run(
        OperationService.Get(
            new OperationFactory(new Register()), args), args.ToInts()))
    : FeedbackService.USAGE);
