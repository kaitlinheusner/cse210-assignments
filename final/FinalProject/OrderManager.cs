public class OrderManager
{
    private List<Food> _currentOrder;

    public OrderManager()
    {
        _currentOrder = new List<Food>();
    }

    public void ViewShopMenu()
    {
        Console.WriteLine("These are our available stores: ");

        Console.WriteLine("1. Tandoori Delights -- Arabian Cuisine ");
        Console.WriteLine("2. Masala Palace -- Indian Cuisine ");

        Console.Write("Which shop would you like to view? ");

        int userChoice = int.Parse(Console.ReadLine());

        switch (userChoice)
        {
            case 1:
                ArabianStore arabianStore = new ArabianStore();
                arabianStore.DisplayMenu();
                break;

            case 2:
                IndianStore indianStore = new IndianStore();
                indianStore.DisplayMenu();
                break;
        }
    }

    public void AddToCart()
    {
        Console.WriteLine("These are our available stores: ");

        Console.WriteLine("1. Tandoori Delights -- Arabian Cuisine ");
        Console.WriteLine("2. Masala Palace -- Indian Cuisine ");

        Console.Write("Which shop would you like to order from? ");

        int storeChoice = int.Parse(Console.ReadLine());
        List<Food> chosenMenu = null;

        switch (storeChoice)
        {
            case 1:
                ArabianStore arabianStore2 = new ArabianStore();
                arabianStore2.DisplayMenu();
                chosenMenu = arabianStore2.GetMenuItems();
                Console.WriteLine();
                break;

            case 2:
                IndianStore indianStore2 = new IndianStore();
                indianStore2.DisplayMenu();
                chosenMenu = indianStore2.GetMenuItems();
                Console.WriteLine();
                break;
        }

        if (chosenMenu != null)
        {
            for (int i = 0; i < chosenMenu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {chosenMenu[i].GetFoodDetailsForMenu()}");
            }

            Console.Write("Enter the number of the item to add to cart: ");
            int itemChoice = int.Parse(Console.ReadLine()) - 1;

            if (itemChoice >= 0 && itemChoice < chosenMenu.Count)
            {
                _currentOrder.Add(chosenMenu[itemChoice]);
                Console.WriteLine("Item added to cart.");
            }

            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }
    }

    public void ViewCart()
    {
        if (_currentOrder.Count == 0)
        {
            Console.WriteLine("There is nothing in your cart.");
        }

        else
        {
            foreach (var food in _currentOrder)
            {
                food.ShowFoodDetailsForOrder();
            }
        }
    }

    public void RemoveFromCart()
    {

    }

    public void DeleteCart()
    {
        if (_currentOrder.Count == 0)
        {
            Console.WriteLine("There is nothing in your cart to clear. ");
        }

        _currentOrder.Clear();
        Console.WriteLine("Your order has been cleared. ");
    }

    public void ConfirmOrder()
    {
        if (_currentOrder.Count == 0)
        {
            Console.WriteLine("There is nothing in your cart");
        }

        Console.WriteLine("Your order is: ");
        Console.WriteLine();

        foreach (var food in _currentOrder)
        {
            food.ShowFoodDetailsForOrder();
        }

        Console.WriteLine("It has been confirmed with the restaurant and will be arriving shortly.");

        _currentOrder.Clear();
    }
}