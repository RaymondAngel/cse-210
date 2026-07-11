using System;
using System.Collections.Generic;

// Stores journal prompts and selects one at random.
public class PromptGenerator
{
    // Provide more than the five prompts required by the assignment.
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I learned about myself today?"
    };

    // Return one prompt from the list using a random index.
    public string GetRandomPrompt()
    {
        // Random.Next chooses a valid list position from zero through Count - 1.
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
