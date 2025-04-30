using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squared = SquareNumber(number);
        DisplayResult(name, squared);

    }
    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber = int.Parse(Console.ReadLine());

        return favoriteNumber;
    }
    
    static int SquareNumber(int number)
    {
        int squared = number * number;
        return squared;
    }

    static void DisplayResult(string name, int square)
    {
        Console.Write($"{name}, the square of your number is {square}");
    }
}