using System;

// Represents one dated response in the journal.
public class Entry
{
    // The calendar date when the user wrote the entry.
    public string _date;

    // The random question that the user answered.
    public string _promptText;

    // The user's written answer to the prompt.
    public string _entryText;

    // An additional detail that records how the user felt that day.
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
