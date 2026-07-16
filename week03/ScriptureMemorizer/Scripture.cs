// Scripture.cs
// The Scripture class brings the other program pieces together. It stores a
// Reference and turns the scripture text into a list of Word objects. It can
// hide random visible words, combine all parts into display text, and report
// when every word has been hidden. Program.cs calls these public methods to
// run each step of the memorization activity. It also supports the extra-credit
// options for hiding a word chosen by the user and revealing all hidden words.

using System;
using System.Collections.Generic;

class Scripture
{
    // These objects contain the scripture's reference and individual words.
    private Reference _reference;
    private List<Word> _words;

    // One Random object is reused each time words need to be selected.
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        // Split the supplied text at spaces and create an object for each word.
        foreach (string word in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // First collect the words that are still available to be hidden.
        List<Word> visibleWords = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        // Near the end, fewer visible words may remain than the requested amount.
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            // Select, hide, and remove a random visible word. Removing it from
            // this temporary list prevents the same word from being chosen twice.
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    // Hide each visible word that matches the text entered by the user.
    // Return the number hidden so Program can provide helpful feedback.
    public int HideWord(string text)
    {
        int hiddenCount = 0;

        foreach (Word word in _words)
        {
            if (!word.IsHidden() && word.Matches(text))
            {
                word.Hide();
                hiddenCount++;
            }
        }

        return hiddenCount;
    }

    // Reveal every word so the user can begin practicing the passage again.
    public void ShowAllWords()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }

    public string GetDisplayText()
    {
        // Ask each Word how it should look in its current visible/hidden state.
        List<string> displayWords = new List<string>();

        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        // Join the reference and words into the single line shown by Program.
        return $"{_reference.GetDisplayText()} {string.Join(" ", displayWords)}";
    }

    public bool IsCompletelyHidden()
    {
        // Finding even one visible word means the activity is not finished.
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        // The loop reached the end without finding a visible word.
        return true;
    }
}
