public class Swimming : Activity
{
    private int _lapCount;

    public Swimming(string date, int lengthMinutes, int lapCount)
        : base(date, lengthMinutes)
    {
        _lapCount = lapCount;
    }

    public override double GetDistance()
    {
        const double metersPerLap = 50;
        const double metersPerKilometer = 1000;
        const double milesPerKilometer = 0.62;

        return _lapCount * metersPerLap / metersPerKilometer * milesPerKilometer;
    }

    public override double GetSpeed()
    {
        return GetDistance() / GetLengthMinutes() * 60;
    }

    public override double GetPace()
    {
        return GetLengthMinutes() / GetDistance();
    }

    protected override string GetActivityName()
    {
        return "Swimming";
    }
}
