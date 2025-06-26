using System.ComponentModel;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetSaveString()
    {
        return $"SimpleGoal:{GetName()},{GetDescription()},{GetPoints()},{_isComplete}";
    }

    public override string GetDetailsString()
    {
        string status;

        if (_isComplete)
        {
            status = "[X]";
        }

        else
        {
            status = "[ ]";
        }

        return $"{status} {GetName()} ({GetDescription()})";
    }

   public new static Goal CreateGoalFromFile(string data)
    {
        string[] parts = data.Split(",");

        string name = parts[0].Trim();
        string desc = parts[1].Trim();
        int points = int.Parse(parts[2].Trim());
        bool isComplete = bool.Parse(parts[3].Trim()); 

        return new SimpleGoal(name, desc, points, isComplete);
    }

}