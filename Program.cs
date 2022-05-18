Console.WriteLine("Which Demo would you like to run? (1 or 2) ");

var choice = Console.ReadLine();

if (choice == null)
    Console.WriteLine("Input stream finished, exiting.");
else if (choice.StartsWith("1"))
    PrincipalDemo.Run();
else if (choice.StartsWith("2"))
    QueryDemo.Run();
else
    Console.WriteLine("Bad choice!");