using System.Net.Security;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public int GetPoints()
    {
        return _points;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public abstract string GetSaveString();
    public abstract string GetDetailsString();
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public static Goal CreateGoalFromFile(string line)
    {
        string[] parts = line.Split(":", 2);
        string type = parts[0].Trim();
        string data = parts[1].Trim();

        return type switch
        {
            "SimpleGoal" => SimpleGoal.CreateGoalFromFile(data),
            "ChecklistGoal" => ChecklistGoal.CreateGoalFromFile(data),
            "EternalGoal" => EternalGoal.CreateGoalFromFile(data),
             _ => throw new Exception($"Unknown goal type: '{type}'")
        };
    }
}