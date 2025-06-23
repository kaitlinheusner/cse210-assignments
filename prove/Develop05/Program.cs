using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        int userChoice = 0;
        Console.WriteLine($"You have {manager.GetTotalPoints()}");

        while (userChoice != 6)
        {
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.WriteLine("Select a choice from the menu: ");

            userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    Console.Write("Select a choice from the menu: ");
                    Console.WriteLine("The types of Goals are: ");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");
                    Console.Write("What type of goal would you like to create? ");
                    int goalChoice = int.Parse(Console.ReadLine());

                    Console.Write("What is the name of your goal? ");
                    string goalName = Console.ReadLine();

                    Console.Write("What is a short description of it? ");
                    string goalDescription = Console.ReadLine();

                    Console.Write("What is the number of point associated with this goal? ");
                    int goalPoints = int.Parse(Console.ReadLine());

                    switch (goalChoice)
                    {
                        case 1:
                            SimpleGoal simplegoal = new SimpleGoal(goalName, goalDescription, goalPoints);
                            manager.AddGoal(simplegoal);
                            break;

                        case 2:
                            EternalGoal eternalgoal = new EternalGoal(goalName, goalDescription, goalPoints);
                            manager.AddGoal(eternalgoal);
                            break;

                        case 3:
                            Console.Write("How may times does this goal need to be accomplished for a bonus? ");
                            int targetCount = int.Parse(Console.ReadLine());

                            Console.Write("What is the bonus for accomplishing it that many times? ");
                            int bonusPoints = int.Parse(Console.ReadLine());

                            ChecklistGoal checklistgoal = new ChecklistGoal(goalName, goalDescription, goalPoints, bonusPoints, targetCount, 0);
                            manager.AddGoal(checklistgoal);
                            break;
                    }

                    break;

                case 2:
                    manager.DisplayGoals();
                    break;

                case 3:
                    manager.SaveGoals();
                    break;

                case 4:
                    manager.LoadGoals();
                    break;

                case 5:
                    manager.RecordGoalEvent();
                    break;

                case 6:
                    break;
            }
        }
        

        
    }
}