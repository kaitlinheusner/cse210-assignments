using System.Runtime.CompilerServices;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;

public class GoalManager
{
    private List<Goal> _goals;
    private int _totalScore;
    private string _filename;

    public GoalManager()
    {
        _goals = new List<Goal>();
    }

    public string GetFilename()
    {
        return _filename;
    }

    public void SetFilename(string filename)
    {
        _filename = filename;
    }

    public int GetTotalPoints()
    {
        return _totalScore;
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void SaveGoals()
    {
        string filename = _filename;

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetSaveString());
            }
        }
    }

    public void LoadGoals()
    {
        _goals.Clear();

        string fileName = _filename;
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split();

            string goalType = parts[0];
            string goalName = parts[1];
            string goalDescription = parts[2];
            int goalPoints = int.Parse(parts[3]);

            if (goalType == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(goalName, goalDescription, goalPoints);
                _goals.Add(goal);
            }

            else if (goalType == "CheckListGoal")
            {
                int bonusPoints = int.Parse(parts[4]);
                int targetCount = int.Parse(parts[5]);
                int currentCount = int.Parse(parts[6]);

                ChecklistGoal goal = new ChecklistGoal(goalName, goalDescription, goalPoints, bonusPoints, targetCount, currentCount);
                _goals.Add(goal);
            }
        }
    }

    public void DisplayGoals()
    {
        int i = 0;

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            i++; 
        }
    }

    public void RecordGoalEvent()
    {
        Console.WriteLine("The goals are: ");

        for (int i = 0; i <= _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        Console.Write("Which goal did you accomplish? ");

        if (int.TryParse(Console.ReadLine(), out int selection))
        {
            int index = selection - 1;

            if (index >= 0 && index <= _goals.Count)
            {
                int pointsEarned = _goals[index].RecordEvent();
                _totalScore += pointsEarned;

                Console.WriteLine($"Congratulations! You earned {pointsEarned} points");
                Console.WriteLine($"You have {_totalScore} points.");
            }

            else
            {
                Console.WriteLine("Please write a valid number");
            }
        }

        else
        {
            Console.WriteLine("Please enter a valid number.");
        }

    }

}
