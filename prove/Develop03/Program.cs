using System;
using System.Net;

class Program
{
    private static List<Scripture> _scriptures = new List<Scripture>()
        {
            new Scripture(new Reference("John", 3, 16),
            "For God so loved the world that he gave his only Son, that whoever believes in him should not perish but have eternal life."),

            new Scripture(new Reference("Alma", 37, 35),
            "O, remember, my son, and learn wisdom in thy youth; yea, learn in thy youth to keep the commandments of God."),

            new Scripture(new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. \nIn all thy ways acknowledge him, and he shall direct thy paths."),

            new Scripture(new Reference("2 Nephi", 2, 24, 25),
            "But behold, all things have been done in the wisdom of him who knoweth all things.\nAdam fell that men might be; and men are, that they might have joy."),

            new Scripture(new Reference("Doctrine and Covenants", 3, 1, 3),
            "The works, and the designs, and the purposes of God cannot be frustrated, neither can they come to naught. \nFor God doth not walk in crooked paths, neither doth he turn to the right hand nor to the left, neither doth he vary from that which he hath said, therefore his paths are straight, and his course is one eternal round. \nRemember, remember that it is not the work of God that is frustrated, but the work of men;"),

            new Scripture(new Reference("Matthew", 3, 16, 17),
            "And Jesus, when he was baptized, went up straightway out of the water: and, lo, the heavens were opened unto him, and he saw the Spirit of God descending like a dove, and lighting upon him: \nAnd lo a voice from heaven, saying, This is my beloved Son, in whom I am well pleased."),

            new Scripture(new Reference("Moses", 2, 3),
            "And I, God, said: Let there be light; and there was light."),
        };

    public static Scripture GetScripture()
    {
        Random random = new Random();
        int index = random.Next(_scriptures.Count);
        return _scriptures[index];
    }

    public static void Main(string[] args)
    {
        Scripture scripture = GetScripture();
        string userInput = "";

        while (userInput == "")
        {
            Console.Clear();
            Console.WriteLine(scripture.GetRenderedText());

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            scripture.HideWords();
        }
    }
}