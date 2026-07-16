// Reference.cs
// The Reference class stores and formats the location of a scripture.
// It supports both a single verse, such as John 3:16, and a verse range,
// such as Proverbs 3:5-6. A Scripture object uses this class when building
// the complete text that is displayed to the user.

class Reference
{
    // These private fields keep the parts of the reference encapsulated.
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // This constructor is used when the reference contains one verse.
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        // Matching start and end verses tells GetDisplayText to show one verse.
        _endVerse = verse;
    }

    // This constructor is used when the reference contains a range of verses.
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        // Do not add a verse range when the start and end verses match.
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }

        // A different end verse means the reference contains a verse range.
        return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}
