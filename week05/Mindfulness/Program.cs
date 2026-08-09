class Program
{
    // Exceeds the core requirements by preventing repeated reflection questions
    // until every question has been shown, and by tracking completed activities
    // during the current session and displaying their total in the main menu.
    static void Main(string[] args)
    {
        int completedActivities = 0;
        string choice;

        do
        {
            ConsoleHelper.ClearScreen();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine($"\nActivities completed this session: {completedActivities}");
            Console.Write("Select a choice from the menu: ");
            string menuInput = Console.ReadLine();
            if (menuInput is null)
            {
                Console.WriteLine("\nInput closed. Goodbye.");
                return;
            }

            choice = menuInput;

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    completedActivities++;
                    break;
                case "2":
                    new ReflectionActivity().Run();
                    completedActivities++;
                    break;
                case "3":
                    new ListingActivity().Run();
                    completedActivities++;
                    break;
                case "4":
                    Console.WriteLine("Thank you for taking time to be mindful today.");
                    break;
                default:
                    Console.WriteLine("Please choose an option from 1 to 4.");
                    Thread.Sleep(1500);
                    break;
            }
        } while (choice != "4");
    }
}
