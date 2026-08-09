public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice;

        do
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine() ?? "6";

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Keep working toward your eternal goals!");
                    break;
                default:
                    Console.WriteLine("Please choose an option from 1 to 6.");
                    break;
            }
        } while (choice != "6");
    }

    public void DisplayPlayerInfo()
    {
        int level = (_score / 500) + 1;
        int pointsTowardNextLevel = _score % 500;
        string title = GetLevelTitle(level);

        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level {level}: {title} ({pointsTowardNextLevel}/500 toward the next level)");
    }

    public void ListGoalNames()
    {
        for (int index = 0; index < _goals.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {_goals[index].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int index = 0; index < _goals.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {_goals[index].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        int goalType = ReadNumber("Which type of goal would you like to create? ", 1, 3);

        Console.Write("What is the name of your goal? ");
        string name = ReadRequiredText();
        Console.Write("What is a short description of it? ");
        string description = ReadRequiredText();
        int points = ReadPositiveNumber("What is the amount of points associated with this goal? ");

        if (goalType == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (goalType == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else
        {
            int target = ReadPositiveNumber("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = ReadPositiveNumber("What is the bonus for accomplishing it that many times? ");
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created successfully.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        ListGoalNames();
        int goalNumber = ReadNumber("Which goal did you accomplish? ", 1, _goals.Count);
        Goal goal = _goals[goalNumber - 1];
        bool wasComplete = goal.IsComplete();
        int earnedPoints = goal.RecordEvent();

        if (wasComplete)
        {
            Console.WriteLine("That goal was already complete, so no additional points were awarded.");
            return;
        }

        _score += earnedPoints;
        Console.WriteLine($"Congratulations! You have earned {earnedPoints} points!");
        Console.WriteLine($"You now have {_score} points.");

        if (goal.IsComplete())
        {
            Console.WriteLine("Goal complete! Great work!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = ReadRequiredText();

        try
        {
            using StreamWriter outputFile = new StreamWriter(filename);
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }

            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException)
        {
            Console.WriteLine($"The goals could not be saved: {exception.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = ReadRequiredText();

        try
        {
            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0 || !int.TryParse(lines[0], out int loadedScore))
            {
                throw new InvalidDataException("The file does not contain a valid score.");
            }

            List<Goal> loadedGoals = new List<Goal>();
            for (int index = 1; index < lines.Length; index++)
            {
                if (!string.IsNullOrWhiteSpace(lines[index]))
                {
                    loadedGoals.Add(ParseGoal(lines[index]));
                }
            }

            _score = loadedScore;
            _goals = loadedGoals;
            Console.WriteLine("Goals loaded successfully.");
        }
        catch (Exception exception) when (
            exception is IOException ||
            exception is UnauthorizedAccessException ||
            exception is FormatException ||
            exception is InvalidDataException ||
            exception is OverflowException)
        {
            Console.WriteLine($"The goals could not be loaded: {exception.Message}");
        }
    }

    private Goal ParseGoal(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length < 4)
        {
            throw new InvalidDataException("A goal entry is incomplete.");
        }

        string type = parts[0];
        string name = Goal.Decode(parts[1]);
        string description = Goal.Decode(parts[2]);
        int points = int.Parse(parts[3]);

        return type switch
        {
            "SimpleGoal" when parts.Length == 5 =>
                new SimpleGoal(name, description, points, bool.Parse(parts[4])),
            "EternalGoal" when parts.Length == 4 =>
                new EternalGoal(name, description, points),
            "ChecklistGoal" when parts.Length == 7 =>
                new ChecklistGoal(
                    name,
                    description,
                    points,
                    int.Parse(parts[4]),
                    int.Parse(parts[5]),
                    int.Parse(parts[6])),
            _ => throw new InvalidDataException($"Unknown or malformed goal type: {type}")
        };
    }

    private int ReadPositiveNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
            {
                return number;
            }

            Console.WriteLine("Please enter a whole number greater than zero.");
        }
    }

    private int ReadNumber(string prompt, int minimum, int maximum)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int number) &&
                number >= minimum && number <= maximum)
            {
                return number;
            }

            Console.WriteLine($"Please enter a number from {minimum} to {maximum}.");
        }
    }

    private string ReadRequiredText()
    {
        while (true)
        {
            string value = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value.Trim();
            }

            Console.Write("Please enter a value: ");
        }
    }

    private string GetLevelTitle(int level)
    {
        return level switch
        {
            1 => "Quest Beginner",
            2 => "Steady Adventurer",
            3 => "Goal Champion",
            4 => "Master Achiever",
            _ => "Eternal Quest Legend"
        };
    }
}
