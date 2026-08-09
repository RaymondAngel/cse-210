public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        int itemCount = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (response is null)
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(response))
            {
                itemCount++;
            }
        }

        string itemLabel = itemCount == 1 ? "item" : "items";
        Console.WriteLine($"\nYou listed {itemCount} {itemLabel}!");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[Random.Shared.Next(_prompts.Count)];
    }
}
