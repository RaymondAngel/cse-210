// Program.cs
// This file is the starting point for the Scripture Memorizer program.
// It creates a Reference and uses it to create a Scripture. It then controls
// the main loop that displays the scripture, reads the user's response, and
// asks the Scripture object to hide words until every word has been hidden.
//
// EXCEEDING REQUIREMENTS:
// In addition to hiding random words, this program lets the user type a word
// from the scripture to hide every occurrence of that specific word. The user
// can also type "show" to reveal all hidden words and restart their practice.
// Instructions for all available commands are displayed during the activity.

using System;

class Program
{
    static void Main(string[] args)
    {
        // A Reference stores the book, chapter, and verse range separately
        // from the words of the scripture.
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        // The Scripture object connects the reference to the scripture text.
        // Its constructor changes each word in the text into a Word object.
        Scripture scripture = new Scripture(
            reference,
            "Trust in the Lord with all thine heart and lean not unto thine own understanding. " +
            "In all thy ways acknowledge him, and he shall direct thy paths."
        );

        // Begin with a welcome screen so the user understands the activity and
        // all available commands before the scripture is displayed.
        Console.Clear();
        Console.WriteLine("SCRIPTURE MEMORIZER");
        Console.WriteLine();
        Console.WriteLine("This program helps you memorize a scripture by hiding words.");
        Console.WriteLine();
        Console.WriteLine("HOW TO USE THE PROGRAM");
        Console.WriteLine("- Press Enter to hide three random words.");
        Console.WriteLine("- Type a word from the scripture to hide that word.");
        Console.WriteLine("- Type 'show' to reveal all hidden words again.");
        Console.WriteLine("- Type 'quit' to finish the program.");
        Console.WriteLine();
        Console.Write("Press Enter to begin: ");
        Console.ReadLine();

        // An empty response represents the user pressing Enter. The message
        // gives feedback after the user enters a command.
        string response = "";
        string message = "";

        // Keep practicing until the user types quit or all words are hidden.
        while (response.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            // Clear the old version before showing the updated scripture.
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("INSTRUCTIONS");
            Console.WriteLine("- Press Enter to hide three random words.");
            Console.WriteLine("- Type a word from the scripture to hide that word.");
            Console.WriteLine("- Type 'show' to reveal all hidden words again.");
            Console.WriteLine("- Type 'quit' to finish.");

            if (message != "")
            {
                Console.WriteLine();
                Console.WriteLine(message);
            }

            Console.WriteLine();
            Console.Write("Your choice: ");
            response = Console.ReadLine() ?? "";
            string command = response.Trim();
            response = command;
            message = "";

            // Decide which action to perform from the user's command.
            if (command == "")
            {
                scripture.HideRandomWords(3);
            }
            else if (command.ToLower() == "show")
            {
                scripture.ShowAllWords();
                message = "All hidden words have been revealed.";
            }
            else if (command.ToLower() != "quit")
            {
                // Any other text is treated as a word the user wants to hide.
                int hiddenCount = scripture.HideWord(command);
                message = hiddenCount > 0
                    ? $"Hidden occurrences of the word '{command}': {hiddenCount}."
                    : $"The visible word '{command}' was not found in the scripture.";
            }
        }

        // If every word was hidden, display the completed version one last time.
        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}
