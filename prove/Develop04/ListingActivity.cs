public class ListingActivity : Activity
{
    private int _listingAttempts;
    private List<string> _listingPrompts = new List<string>()
    {
        new string("Who are people that you appreciate?"),
        new string("What are personal strengths of yours?"),
        new string("Who are people that you have helped this week?"),
        new string("When have you felt the Holy Ghost this month?"),
        new string("Who are some of your personal heroes?")
    };

    public ListingActivity(int duration):
    base("Listing Activity",
    "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
    duration)
    {
        _duration = duration;
    }

    public string GetRandomListingPrompt()
    {
        Random random = new Random();
        int index = random.Next(_listingPrompts.Count);
        return _listingPrompts[index];
    }

    public void DisplayListingPrompt()
    {
        Console.WriteLine($" --- {GetRandomListingPrompt()} ---");
    }

    public int GetListingAttempts()
    {
        return _listingAttempts;
    }

    public void DisplayListingAttempts()
    {
        Console.WriteLine($"You have completed the Listing Activity {_listingAttempts} time(s).");
    }

    public void RunListingActivity()
    {
        DisplayStartMessage();
        Console.WriteLine();

        Console.WriteLine("List as many responses you can to the following prompt: ");
        DisplayListingPrompt();
        Console.Write("You may begin in: ");
        CountdownPause(5);


        DateTime endActivity = DateTime.Now.AddSeconds(_duration);

        int listCount = 0;

        while (DateTime.Now < endActivity)
        {
            Console.WriteLine("> ");
            string userInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(userInput))
            {
                listCount++;
            }
        }

        Console.WriteLine($"You listed {listCount} times");
        Console.WriteLine();

        _listingAttempts++;
        DisplayEndMessage();

    }
}