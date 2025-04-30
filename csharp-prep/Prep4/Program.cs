using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int userInput = -1;
        List<int> numbers = new List<int>();
        int sum = 0;

        while (userInput != 0)
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());

            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }

        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is {sum}");

        float average = ((float)sum)/numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int biggestNumber = -1;
        foreach (int number in numbers)
        {
            if (number > biggestNumber)
            {
                biggestNumber = number;
            }
        }

        Console.WriteLine($"The largest number is: {biggestNumber}");

    }
}