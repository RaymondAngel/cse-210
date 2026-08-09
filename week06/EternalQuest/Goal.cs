using System.Text;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string marker = IsComplete() ? "[X]" : "[ ]";
        return $"{marker} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();

    protected string GetBaseString()
    {
        return $"{Encode(_shortName)}|{Encode(_description)}|{_points}";
    }

    protected static string Encode(string value)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
    }

    public static string Decode(string value)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(value));
    }
}
