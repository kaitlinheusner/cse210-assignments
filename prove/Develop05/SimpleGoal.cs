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

        return $"{status} {GetName()} ({GetDetailsString()})";
    }

   public static Goal CreateFromData(string data)
    {
        string[] parts = data.Split(",");
        string name = parts[0];
        string desc = parts[1];
        int points = int.Parse(parts[2]);
        bool isComplete = bool.Parse(parts[3]); 

        return new SimpleGoal(name, desc, points, isComplete);
    }

}