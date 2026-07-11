using System;

// Represents one dated response in the journal.
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;

    // Display all information belonging to this entry.
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }
}
