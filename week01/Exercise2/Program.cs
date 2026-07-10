using System;

class Program
{
    static void Main(string[] args)
    {
        int percentage;

        while (true)
        {
            Console.Write("What is your grade percentage? ");
            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out percentage))
            {
                Console.WriteLine("Invalid input. Please enter a number value.");
            }
            else if (percentage < 10)
            {
                Console.WriteLine("Invalid input. The grade percentage must be at least 10.");
            }
            else if (percentage > 100)
            {
                Console.WriteLine("Invalid input. The grade percentage cannot be greater than 100.");
            }
            else
            {
                break;
            }
        }

        string letter;

        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int lastDigit = percentage % 10;
        string sign;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // There are no A+ grades, and scores of 93 or higher are a plain A.
        if (letter == "A" && percentage >= 93)
        {
            sign = "";
        }

        // F grades never have a plus or minus sign.
        if (letter == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your letter grade is {letter}{sign}.");

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard. You can do better next time!");
        }
    }
}
