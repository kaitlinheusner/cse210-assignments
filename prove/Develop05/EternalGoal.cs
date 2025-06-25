public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetSaveString()
    {
        return $"EternalGoal:{GetName()},{GetDescription()},{GetPoints()}";
    }

    public override string GetDetailsString()
    {
        return $"[ ] {GetName()} ({GetDescription()})";
    }
    
    public new static Goal CreateGoalFromFile(string data)
    {
        string[] parts = data.Split(",");
        string name = parts[0];
        string desc = parts[1];
        int points = int.Parse(parts[2]);

        return new EternalGoal(name, desc, points);
    }
}