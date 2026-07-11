using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the random number generator and store the player's replay choice.
        Random randomGenerator = new Random();
        string playAgain;

        // Run the full game at least once and repeat when the player enters "yes."
        do
        {
            // Choose a new magic number and reset the guess information for each game.
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int guessCount = 0;

            // Keep asking for guesses until the player finds the magic number.
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine() ?? "0");
                guessCount++;

                // Give the player a hint or confirm the correct answer.
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Show the final guess count and ask whether to start a new game.
            Console.WriteLine($"You made {guessCount} guesses.");
            Console.Write("Would you like to play again? ");
            playAgain = (Console.ReadLine() ?? "no").ToLower();
        }
        while (playAgain == "yes");

        // End the program when the player chooses not to play again.
        Console.WriteLine("Thanks for playing!");
    }
}
