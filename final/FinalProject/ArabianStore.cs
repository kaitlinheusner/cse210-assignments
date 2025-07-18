public class ArabianStore : Store
{
    public ArabianStore() : base("Tandoori Delights", "rich and savory food from the Middle East", new List<Food>
                            {
                                new ArabianFood("Shawarma", "Chicken wrapped in pita", 0),
                                new ArabianFood("Hummus", "Chickpea dip", 0),
                                new ArabianFood("Warak Enab", "Spice covered rice wrapped in grape leaves", 0),
                                new ArabianFood("Falafel", "Fried balls that are made up of chickpeas or fava beans", 0),
                                new ArabianFood("Tabouleh", "A refreshing salad containing tomatoes, mint, and parsley", 0)
                            })
    {
    }

    public override void DisplayMenu()
    {
        Console.WriteLine();

        Console.WriteLine($"Welcome to {GetStoreName()}!");
        Console.WriteLine($"We offer {GetStoreDescription()} ");

        Console.WriteLine();
        Console.WriteLine("Here is our Arabian Menu: ");
        Console.WriteLine();

        Console.WriteLine("------------------------------");
        Console.WriteLine();

        foreach (var food in _menuItems)
        {
            food.ShowFoodDetailsForMenu();
        }

        Console.WriteLine();
        Console.WriteLine("------------------------------");
    }
}