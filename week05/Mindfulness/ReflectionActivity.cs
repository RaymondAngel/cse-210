public class ReflectionActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        ConsoleHelper.ClearScreen();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        Queue<string> questions = CreateShuffledQuestions();

        while (DateTime.Now < endTime)
        {
            if (questions.Count == 0)
            {
                questions = CreateShuffledQuestions();
            }

            Console.Write($"> {questions.Dequeue()} ");
            ShowSpinner(Math.Min(10, Math.Max(1, (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds))));
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[Random.Shared.Next(_prompts.Count)];
    }

    private Queue<string> CreateShuffledQuestions()
    {
        return new Queue<string>(_questions.OrderBy(_ => Random.Shared.Next()));
    }
}
