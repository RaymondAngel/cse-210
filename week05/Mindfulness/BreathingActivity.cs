public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(Math.Min(4, SecondsRemaining(endTime)));

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("\nBreathe out... ");
            ShowCountDown(Math.Min(6, SecondsRemaining(endTime)));
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private int SecondsRemaining(DateTime endTime)
    {
        return Math.Max(1, (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds));
    }
}
