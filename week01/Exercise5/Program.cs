using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(favoriteNumber);

        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine() ?? "";
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber = int.Parse(Console.ReadLine() ?? "0");
        return favoriteNumber;
    }

    static int SquareNumber(int number)
    {
        int squaredNumber = number * number;
        return squaredNumber;
    }

    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }
}
