public class Fraction
{
    // These private variables store the numerator (top number) and
    // denominator (bottom number) of the fraction.
    private int _top;
    private int _bottom;

    // This constructor creates the default fraction 1/1.
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // This constructor uses the given top number and sets the bottom to 1.
    // For example, new Fraction(5) creates the fraction 5/1.
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // This constructor lets the caller provide both parts of the fraction.
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Returns the current top number (numerator).
    public int GetTop()
    {
        return _top;
    }

    // Changes the top number (numerator) to a new value.
    public void SetTop(int top)
    {
        _top = top;
    }

    // Returns the current bottom number (denominator).
    public int GetBottom()
    {
        return _bottom;
    }

    // Changes the bottom number (denominator) to a new value.
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Returns the fraction as text with a slash, such as "3/4".
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Divides the top by the bottom and returns the decimal result.
    // Casting _top to double prevents C# from using integer division.
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
