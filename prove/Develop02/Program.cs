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
        Journal journal = new Journal();
        int menuChoice = 0;

        Console.WriteLine("Welcome to the Journal Program!");

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
                Entry entry = new Entry();
                entry.WriteEntry();
                journal.AddEntry(entry);
            }

            else if (menuChoice == 2)
            {
                journal.Display();
            }

            else if (menuChoice == 3)
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();
                journal._fileName = fileName;
                journal.LoadJournal();
            }

            else if (menuChoice == 4)
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();
                journal._fileName = fileName;
                journal.SaveJournal();
            }

            else if (menuChoice == 5)
            {
                break;
            }
        }
        
    }
}

public class Journal
{
    private List<Entry> _entries = new List<Entry> ();
    public string _fileName;
    
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveJournal()
    {
        using (StreamWriter outputFile = new StreamWriter(_fileName, false))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }
    }

    public void LoadJournal()
    {
        _entries.Clear();        
        string[] journalEntries = System.IO.File.ReadAllLines(_fileName);

        foreach (string journalEntry in journalEntries)
        {
            string[] entryParts = journalEntry.Split("|");
            string date = entryParts[0];
            string prompt = entryParts[1];
            string response = entryParts[2];

            Entry entry = new Entry();
            entry._date = date;
            entry._prompt = prompt;
            entry._response = response;

            _entries.Add(entry);
        }
    }
}

public class Entry
{
    public string _prompt;
    public string _response;
    public string _date;

    public void WriteEntry()
    {
        _prompt = PromptGenerator.PromptMenu();
        Console.WriteLine(_prompt);
        Console.Write("> ");
        _response = Console.ReadLine();
        Console.WriteLine("");
        _date = DateTime.Now.ToShortDateString();
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
        Console.WriteLine("");
    }
}

public class PromptGenerator
{
    static List<string> _familyPrompts = new List<string>()
        {
            "What is a fun memory you have with your family? ",
            "How many siblings do you have? ", 
            "Where are your parents from? ",
        };

    static List<string> _schoolPrompts = new List<string>()
        {
            "What do you enjoy about school? ",
            "How have your assignments been going?", 
            "What is your favorite class? "
        };

    static List<string> _naturePrompts = new List<string>()
        {
            "What is your favorite weather? ",
            "What did you enjoy about the outdoors today?",
            "Do you like flowers? (If yes, do you have a favorite?)", 

        };

    static List<string> _lifePrompts = new List<string>()
    {
        "How have things been going recently? ",
        "Who was the most interesting person I interacted with today?",
        "How did I see the hand of the Lord in my life today? "
    };

    public static string PromptMenu()
    {
        Console.WriteLine("");
        Console.Write("Please select a prompt suggestion for what you would like to write about: ");

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
            int index = rnd.Next(_naturePrompts.Count);
            prompt = _naturePrompts[index];
        }

        else if (promptChoice == 4)
        {
            int index = rnd.Next(_lifePrompts.Count);
            prompt = _lifePrompts[index];
        }
    
        return prompt;
    }
}