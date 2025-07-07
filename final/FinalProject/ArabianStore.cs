public class ArabianStore : Store
{

    public ArabianStore() : base("Tandoori Delights", "Rich, savory food from the Middle East", new List<Food>
                            {
                                new ArabianFood("Shawarma", "Chicken wrapped in pita", 0),
                                new ArabianFood("Hummus", "Chickpea dip", 0)
                            })
    {
    }

    public override string GetStoreName()
    {
        return _storeName;
    }

    public override void DisplayMenu()
    {
        Console.WriteLine($"Welcome to {GetStoreName()}!");
        Console.WriteLine();

        Console.WriteLine("Menu: ");

        foreach (var food in _menuItems)
        {
            food.ShowFoodDetailsForMenu();
        }
    }
}