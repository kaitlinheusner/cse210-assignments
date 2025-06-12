public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    private List<string> _animationStrings = new List<string>();

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine();

        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.Clear();

        Console.WriteLine("Get ready...");
        SpinnerPause();
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("Well Done!");
        SpinnerPause();

        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}");

        SpinnerPause();
        Console.WriteLine();

        Console.Clear();
    }

    public void SpinnerPause()
    {
        _animationStrings.Add("|");
        _animationStrings.Add("/");
        _animationStrings.Add("-");
        _animationStrings.Add("\\");
        _animationStrings.Add("|");
        _animationStrings.Add("/");
        _animationStrings.Add("-");
        _animationStrings.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(5);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = _animationStrings[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");

            i++;

            if (i >= _animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void CountdownPause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}