using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity features: Each entry records the user's mood, and journals
        // are stored as JSON so responses containing commas or symbols remain safe.
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string choice = "";

        // Keep showing the menu until the user chooses to quit.
        while (choice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                // Create a new entry from a random prompt and the user's answers.
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();
                Console.Write("How would you describe your mood today? ");
                string mood = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;
                entry._mood = mood;
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                try
                {
                    journal.LoadFromFile(filename);
                    Console.WriteLine("Journal loaded successfully.");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"The journal could not be loaded: {exception.Message}");
                }
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                try
                {
                    journal.SaveToFile(filename);
                    Console.WriteLine("Journal saved successfully.");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"The journal could not be saved: {exception.Message}");
                }
            }
            else if (choice != "5")
            {
                Console.WriteLine("Please enter a number from 1 to 5.");
            }
        }
    }
}
