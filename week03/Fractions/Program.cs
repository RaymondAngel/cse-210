// Fractions Program
// This program creates and displays fractions in fractional and decimal forms.
// Each Fraction object stores a top number (numerator) and a bottom number
// (denominator). Fractions can be created with different starting values and
// updated when needed through the methods provided by the Fraction class.

class Program
{
    static void Main(string[] args)
    {
        // Create and display fractions using each of the three constructors.
        Fraction fraction1 = new Fraction();
        DisplayFraction(fraction1);

        Fraction fraction2 = new Fraction(5);
        DisplayFraction(fraction2);

        Fraction fraction3 = new Fraction(3, 4);
        DisplayFraction(fraction3);

        // Create a fraction and use setters to change it from 1/1 to 1/3.
        Fraction fraction4 = new Fraction();
        fraction4.SetTop(1);
        fraction4.SetBottom(3);

        // Use the getters to retrieve and display the updated values.
        Console.WriteLine($"{fraction4.GetTop()}/{fraction4.GetBottom()}");
        Console.WriteLine(fraction4.GetDecimalValue());
    }

    // This helper method displays both forms of any Fraction object.
    // Using a helper avoids repeating the same WriteLine statements.
    static void DisplayFraction(Fraction fraction)
    {
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
    }
}
