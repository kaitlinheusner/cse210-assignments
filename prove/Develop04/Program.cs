using System;

class Program
{
    static void Main(string[] args)
    {
        int userChoice = 0;

        BreathingActivity breathing = new BreathingActivity(0);
        ReflectingActivity reflecting = new ReflectingActivity(0);
        ListingActivity listing = new ListingActivity(0);

        while (userChoice != 5)
        {
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Check Actvity Attempts");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");

            userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    breathing.RunBreathingActivity();
                    break;

                case 2:
                    reflecting.RunReflectingActivity();
                    break;

                case 3:
                    listing.RunListingActivity();
                    break;

                case 4:
                    Console.WriteLine();
                    Console.WriteLine("You can check how many times you've done an activity. Choose from the list below: ");
                    Console.WriteLine("1. Breathing Activity");
                    Console.WriteLine("2. Reflecting Activity");
                    Console.WriteLine("3. Listing Activity");
        
                    Console.Write("Select your choice: ");

                    int userAttemptChoice = int.Parse(Console.ReadLine());

                    switch (userAttemptChoice)
                    {
                        case 1:
                            breathing.DisplayBreathingAttempts();
                            break;

                        case 2:
                            reflecting.DisplayReflectListAttempts();
                            break;

                        case 3:
                            listing.DisplayListingAttempts();
                            break;

                    }
                    Console.WriteLine();
                    break;

                case 5:
                    break;
            }
        }


    }
}