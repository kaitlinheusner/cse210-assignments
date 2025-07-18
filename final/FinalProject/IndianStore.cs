public class IndianStore : Store
{
    public IndianStore() : base("Masala Palace", "Food from India",new List<Food>
                            {
                                new IndianFood("Butter Chicken", "Chicken wrapped in pita", 0),
                                new IndianFood("Tikka Masala", "Rich, spicy curry", 0), 
                                new IndianFood("Palak Paneer", "Curry made from spinach", 0)
                            })
    {
    }

    public override void DisplayMenu()
    {
        Console.WriteLine();

        Console.WriteLine($"Welcome to {GetStoreName()}!");
        Console.WriteLine($"We offer, {GetStoreDescription()} ");
        
        Console.WriteLine("Enjoy our Indian dishes: ");
        Console.WriteLine();

        Console.WriteLine("******************************");
        Console.WriteLine();

        foreach (var food in _menuItems)
        {
            food.ShowFoodDetailsForMenu();
        }

        Console.WriteLine();
        Console.WriteLine("******************************");
    }
}