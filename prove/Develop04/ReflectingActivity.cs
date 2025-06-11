using System.Security.Cryptography.X509Certificates;

public class ReflectingActivity : Activity
{
    private int _reflectingAttempts;
    private List<string> _prompts = new List<string>()
    {
        new string("Think of a time when you stood up for someone else."),
        new string("Think of a time when you did something really difficult."),
        new string("Think of a time when you helped someone in need."),
        new string("Think of a time when you did something truly selfless.")
    };

    private List<string> _questions = new List<string>()
    {
        new string("Why was this experience meaningful to you?"),
        new string("Have you ever done anything like this before?"),
        new string("How did you get started?"),
        new string("How did you feel when it was complete?"),
        new string("What made this time different than other times when you were not as successful?"),
        new string("What is your favorite thing about this experience?"),
        new string("What could you learn from this experience that applies to other situations?"),
        new string("What did you learn about yourself through this experience?"),
        new string("How can you keep this experience in mind in the future?"),
    };


    public ReflectingActivity(int duration):
    base("Reflecting Activity",
    "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
    duration)
    {
        _duration = duration;
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count());
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
    }

    public void DisplayQuestion()
    {
        Console.Write($"> {GetRandomQuestion()} ");
    }

    public int GetReflectingAttempts()
    {
        return _reflectingAttempts;
    }

    public void DisplayReflectListAttempts()
    {
        Console.WriteLine($"You have done the Reflecting Activity {_reflectingAttempts} time(s).");
    }

    public void RunReflectingActivity()
    {
        DisplayStartMessage();
        Console.WriteLine();

        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine();

        DisplayPrompt();
        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        string userInput = Console.ReadLine();

        if (userInput == "")
        {
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience. ");
            Console.Write("You may begin in: ");
            CountdownPause(3);

            Console.Clear();

            DateTime endActivity = DateTime.Now.AddSeconds(_duration);

            while (DateTime.Now < endActivity)
            {
                DisplayQuestion();
                SpinnerPause();
                Console.WriteLine();
            }

            Console.WriteLine();
            _reflectingAttempts++;
            DisplayEndMessage();
        }
    }
}