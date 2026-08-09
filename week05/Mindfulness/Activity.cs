public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        ConsoleHelper.ClearScreen();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        _duration = ReadPositiveNumber("How long, in seconds, would you like for your session? ");

        ConsoleHelper.ClearScreen();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(2);
        string timeUnit = _duration == 1 ? "second" : "seconds";
        Console.WriteLine($"\nYou have completed another {_duration} {timeUnit} of the {_name}.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int frame = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[frame]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            frame = (frame + 1) % frames.Length;
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int number = seconds; number > 0; number--)
        {
            Console.Write(number);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    private int ReadPositiveNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
            {
                return number;
            }

            Console.WriteLine("Please enter a whole number greater than zero.");
        }
    }
}
