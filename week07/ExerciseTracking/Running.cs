public class Running : Activity
{
    private double _distanceMiles;

    public Running(string date, int lengthMinutes, double distanceMiles)
        : base(date, lengthMinutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        return _distanceMiles / GetLengthMinutes() * 60;
    }

    public override double GetPace()
    {
        return GetLengthMinutes() / _distanceMiles;
    }

    protected override string GetActivityName()
    {
        return "Running";
    }
}
