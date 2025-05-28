using System;
using System.Net;

class Program
{
    static List<Scripture> _scriptures = new List<Scripture>()
        {
            new Scripture(new Reference("John", 3, 16), "For For God so loved the world that he gave his only Son, that whoever believes in him should not perish but have eternal life."),
            new Scripture(new Reference("Alma", 37, 35), "O, remember, my son, and learn wisdom in thy youth; yea, learn in thy youth to keep the commandments of God.")

        };

    static Scripture GetScripture()
    {
        Random random = new Random();
        int index = random.Next(_scriptures.Count);
        return _scriptures[index];
    }


    static void Main(string[] args)
    {
        Scripture scripture = GetScripture();
        string user_input = "";

        while (user_input == "")
        {
            Console.Clear();
            Console.WriteLine(scripture.GetRenderedText());

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            user_input = Console.ReadLine();

            if (user_input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideWords();

        }

    }
}