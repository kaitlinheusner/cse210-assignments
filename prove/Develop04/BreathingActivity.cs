public class BreathingActivity : Activity
{
    private bool _isBreathingIn;

    public BreathingActivity(int duration) : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", duration)
    {
        
        _isBreathingIn = true;
    }

    public void RunBreathingActivity()
    {
        DisplayStartMessage();

        DateTime endActivity = DateTime.Now.AddSeconds(_duration);

        int breathCycleCount = 0;

        while (DateTime.Now < endActivity)
        {
            if (_isBreathingIn)
            {
                Console.Write("Breathe in...");
                CountdownPause(3);
            }

            else if (_isBreathingIn == false)
            {
                Console.Write("Now breathe out...");
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

        DisplayEndMessage();
        SpinnerPause();

    }

}