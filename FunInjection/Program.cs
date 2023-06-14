using FunInjectionLib;

if (OperationService.IsValidOperation(args))
    Console.WriteLine(Feedback.ForOperation(args[0], OperationService.TryOperation(args)));
else
    Console.WriteLine(Feedback.USAGE);
