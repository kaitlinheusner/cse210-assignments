public class IndianStore : Store
{
    public IndianStore() : base("Masala Palace", "vibrant and exciting dishes from India",new List<Food>
                            {
                                new IndianFood("Butter Chicken", "Creamy, tomato based curry with chicken", 0),
                                new IndianFood("Tikka Masala", "Rich, spicy curry", 0),
                                new IndianFood("Palak Paneer", "Curry made from spinach", 0),
                                new IndianFood("Biryani", "A rice dish mixed with meat and vegetables", 0),
                                new IndianFood("Samosa", "A pastry filled with spicy vegetables and chicken", 0)
                            })
    {
    }

    public override void DisplayMenu()
    {
        Console.WriteLine();

        Console.WriteLine($"Welcome to {GetStoreName()}!");
        Console.WriteLine($"We offer {GetStoreDescription()} ");
        
        Console.WriteLine();
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