public class IndianStore : Store
{
    public IndianStore() : base("Masala Palace", "Food from India",new List<Food>
                            {
                                new ArabianFood("Butter Chicken", "Chicken wrapped in pita", 0),
                                new ArabianFood("Tikka Masala", "Rich, spicy curry", 0)
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