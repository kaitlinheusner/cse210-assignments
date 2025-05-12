using System;
using System.ComponentModel.DataAnnotations;
using System.IO.Enumeration;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
       Menu();
    }

    static void Menu()
    {
        Console.WriteLine("Welcome to the Journal Program!");
        int menuChoice = 0;
        while (menuChoice != 5)
        {
            Console.Write("Please select one of the following choices: ");

            string choices = 
            "\r\n" +
            "1. Write \r\n" + 
            "2. Display \r\n" +
            "3. Load \r\n" +
            "4. Save \r\n" +
            "5. Quit \r\n";
            Console.WriteLine(choices);

            Console.Write("What would you like to do? ");
            Console.Write("");
            menuChoice = int.Parse(Console.ReadLine()); 

            
            if (menuChoice == 1)
            {
                var (prompt, response) = Entry.WriteEntry();
                Journal.AddEntry(prompt, response);
            }

            else if (menuChoice == 2)
            {
                Journal.Display();
            }

            else if (menuChoice == 4)
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                Journal.SaveJournal(filename);
            }
        }
        
    }
}

public class Journal
{
    private static List<(string prompt, string response)> entries = new List<(string, string)> ();
    
    public static void AddEntry(string prompt, string response)
    {
        entries.Add((prompt, response));
    }
    public static void Display()
    {
        string dataText = DateTime.Now.ToShortDateString();
        foreach (var (prompt, response) in entries)
        {
            Console.WriteLine($"Date: {dataText} - Prompt {prompt}");
            Console.WriteLine(response);
        }
    }

    public static void SaveJournal(string filename)
    {
        string dataText = DateTime.Now.ToShortDateString(); 

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var (prompt, response) in entries)
            {
                outputFile.WriteLine($"Date: {dataText} - Prompt {prompt}");
                outputFile.WriteLine(response);
            }
        }
    }

    public static void LoadJournal(string filename)
    {

    }
}

public class Entry
{
    public static (string prompt, string response) WriteEntry()
    {
        string prompt = PromptGenerator.PromptMenu();
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        return (prompt, response);
    }
}

public class PromptGenerator
{
    static List<string> _familyPrompts = new List<string>()
        {
            "What is a fun memory you have with your family."
        };

    static List<string> _schoolPrompts = new List<string>()
        {
            "What did you enjoy about school?"
        };

    static List<string> _weatherPrompts = new List<string>()
        {
            "What is your favorite weather? "
        };

    static List<string> _lifePrompts = new List<string>()
    {
        "How have things been going recently? "
    };

    public static string PromptMenu()
    {
        Console.WriteLine("");
        Console.Write("Please select what you would like to write about: ");

        string promptChoices = 
        "\r\n" +
        "1. Family \r\n" + 
        "2. School \r\n" +
        "3. Weather \r\n" +
        "4. Life \r\n";
        Console.WriteLine(promptChoices);

        Console.Write("Which would you like to write about? ");
        int promptChoice = int.Parse(Console.ReadLine());

        string prompt = "";
        Random rnd = new Random();

        if (promptChoice == 1)
        {
            int index = rnd.Next(_familyPrompts.Count);
            prompt = _familyPrompts[index];
        }

        else if (promptChoice == 2)
        {
            int index = rnd.Next(_schoolPrompts.Count);
            prompt = _schoolPrompts[index];
        }

        else if (promptChoice == 3)
        {
            int index = rnd.Next(_weatherPrompts.Count);
            prompt = _weatherPrompts[index];
        }

        else if (promptChoice ==4 )
        {
            int index = rnd.Next(_lifePrompts.Count);
            prompt = _lifePrompts[index];
        }
    
        return prompt;
    }
}