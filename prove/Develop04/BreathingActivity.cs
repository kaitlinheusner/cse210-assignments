public class BreathingActivity : Activity
{
    private bool _isBreathingIn;
    private int _breathingAttempts;

    public BreathingActivity(int duration):
    base("Breathing Activity",
    "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",
    duration)
    {
        _duration = duration;
    }

    public int GetBreathingAttempts()
    {
        return _breathingAttempts;
    }

    public void DisplayBreathingAttempts()
    {
        Console.WriteLine($"You have completed the Breathing Activity {_breathingAttempts} time(s).");
    }

    public void RunBreathingActivity()
    {
        DisplayStartMessage();
        Console.WriteLine();

        DateTime endActivity = DateTime.Now.AddSeconds(_duration);

        int breathCycleCount = 0;
        _isBreathingIn = true;

        while (DateTime.Now <= endActivity)
        {
            if (_isBreathingIn)
            {
                Console.Write("Breathe in...");
                CountdownPause(3);
            }

            else if (_isBreathingIn == false)
            {
                Console.Write("Breathe out...");
                CountdownPause(3);
            }

            Console.WriteLine();
            _isBreathingIn = !_isBreathingIn;
            breathCycleCount++;

            if (breathCycleCount % 2 == 0)
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine();
        _breathingAttempts++;
        DisplayEndMessage();
    }

}