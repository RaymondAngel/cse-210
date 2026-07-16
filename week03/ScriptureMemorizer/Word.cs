// Word.cs
// The Word class represents one word from the scripture. It remembers the
// original text and whether that word is currently hidden. The Scripture
// class holds a list of Word objects and tells selected words to hide or show.

class Word
{
    // The fields are private so a word can only be changed through its methods.
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        // Every word begins in a visible state.
        _isHidden = false;
    }

    // Mark this word as hidden. The original text is kept for its length.
    public void Hide()
    {
        _isHidden = true;
    }

    // Reveal this word again without changing its original text.
    public void Show()
    {
        _isHidden = false;
    }

    // Scripture uses this method to determine which words remain visible.
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Check whether user input matches this word. Punctuation at the beginning
    // or end is ignored so entering "understanding" matches "understanding."
    public bool Matches(string text)
    {
        string wordWithoutPunctuation = _text.Trim(
            '.', ',', ';', ':', '!', '?', '"', '\'', '(', ')'
        );

        return wordWithoutPunctuation.Equals(
            text.Trim(),
            StringComparison.OrdinalIgnoreCase
        );
    }

    // Return either the original word or matching underscores for display.
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Use one underscore for each character in the original word.
            return new string('_', _text.Length);
        }

        return _text;
    }
}
