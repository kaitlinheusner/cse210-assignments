using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage?");
        string gradePercentageFromUser = Console.ReadLine();

        int gradePercentage = int.Parse(gradePercentageFromUser);
        string letter = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }

        else if (gradePercentage >= 80)
        {
            letter = "B";
        }

        else if (gradePercentage >= 70)
        {
            letter = "C";
        }

        else if (gradePercentage >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is {letter}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("You passed the class!");
        }

        else
        {
            Console.WriteLine("You did not pass the class. Better luck next time!");
        }
    }
}