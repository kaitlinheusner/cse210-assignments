using System.ComponentModel;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
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
        return $"SimpleGoal,{GetName()}, {GetDescription()}, {GetPoints()}, {_isComplete}";
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

}