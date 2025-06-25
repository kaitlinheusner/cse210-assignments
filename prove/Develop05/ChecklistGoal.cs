using System.Runtime.InteropServices;

public class ChecklistGoal : Goal
{
    private int _bonusPoints;
    private int _targetCount;
    private int _currentCount;

    public ChecklistGoal(string name, string description, int points, int bonusPoints, int targetCount, int currentCount) : base(name, description, points)
    {
        _bonusPoints = bonusPoints;
        _targetCount = targetCount;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _currentCount++;

            if (_currentCount >= _targetCount)
            {
                return GetPoints() + _bonusPoints;
            }

            return GetPoints();
        }

        return 0;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_bonusPoints},{_targetCount},{_currentCount}";
    }

    public override string GetDetailsString()
    {
        string status;
        if (IsComplete())
        {
            status = "[X]";
        }

        else
        {
            status = "[ ]";
        }

        return $"{status} {GetName()} ({GetDetailsString()}) -- Currently Completed: {_currentCount}/{_targetCount} ";
    }

    
    public static Goal CreateFromData(string data)
    {
        string[] parts = data.Split(",");
        string name = parts[0];
        string desc = parts[1];
        int points = int.Parse(parts[2]);
        int bonus = int.Parse(parts[3]);
        int target = int.Parse(parts[4]);
        int current = int.Parse(parts[5]);

        return new ChecklistGoal(name, desc, points, bonus, target, current);
    }
}