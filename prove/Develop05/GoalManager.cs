using System.Runtime.CompilerServices;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;

public class GoalManager
{
    private List<Goal> _goals;
    private int _totalScore;
    private string _fileName;
    private List<Goal> _incompleteGoals;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _incompleteGoals = new List<Goal>();
    }

    public string GetFilename()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        _fileName = fileName;
        
        return _fileName;
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
        string fileName = _fileName;

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_totalScore);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetSaveString());
            }
        }
    }

    public void LoadGoals()
    {
        _goals.Clear();

        string[] lines = File.ReadAllLines(_fileName);
        _totalScore = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = Goal.CreateGoalFromFile(lines[i]);
            _goals.Add(goal);
        }
    }

    public void DisplayGoals()
    {
        int i = 0;

        Console.WriteLine("The goals are: ");        

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i + 1}. {goal.GetDetailsString()}");
            i++;
        }
    }

    public void SuggestGoal()
    {
        _incompleteGoals.Clear();

        foreach (Goal goal in _goals)
        {
            if (!goal.IsComplete())
            {
                _incompleteGoals.Add(goal);
            }
        }

        if (_incompleteGoals.Count == 0)
        {
            Console.WriteLine("There are no goals for you to work on. ");
            return;
        }

        Console.WriteLine("A goal that you could work on is: ");

        Random random = new Random();
        int index = random.Next(_incompleteGoals.Count);
        Goal suggestedGoal = _incompleteGoals[index];

        Console.WriteLine($"{suggestedGoal.GetName()} {suggestedGoal.GetDescription()}");
    }

    public void RecordGoalEvent()
    {
        Console.WriteLine("The goals are: ");

        for (int i = 0; i < _goals.Count; i++)
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

                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points");
                Console.WriteLine($"You now have {_totalScore} points.");
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
