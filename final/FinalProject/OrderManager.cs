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
                chosenMenu = arabianStore2.GetMenuItems();
                Console.WriteLine();
                break;

            case 2:
                IndianStore indianStore2 = new IndianStore();
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
                Console.Write("Enter the quantity of the item: ");
                int quantity = int.Parse(Console.ReadLine());

                Food selectedItem = chosenMenu[itemChoice];
                Food itemToAdd = null;

                if (selectedItem is ArabianFood)
                {
                    itemToAdd = new ArabianFood(
                        selectedItem.GetName(),
                        selectedItem.GetDescription(),
                        quantity
                    );
                }

                else if (selectedItem is IndianFood)
                {
                    itemToAdd = new IndianFood(
                        selectedItem.GetName(),
                        selectedItem.GetDescription(),
                        quantity
                    );
                }

                if (itemToAdd != null)
                {
                    _currentOrder.Add(itemToAdd);
                    Console.WriteLine("Item added to cart.");
                }
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
        if (_currentOrder.Count == 0)
        {
            Console.WriteLine("There is nothing in your cart.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Your current cart: ");

        for (int i = 0; i < _currentOrder.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_currentOrder[i].GetFoodDetailsForOrder()}");
        }

        Console.WriteLine();

        Console.WriteLine("Would you like to: ");
        Console.WriteLine("1. Remove item from Cart ");
        Console.WriteLine("2. Adjust quantity");
        Console.WriteLine();

        Console.Write("Enter the number of the action you would like to do: ");
        int removeChoice = int.Parse(Console.ReadLine());

        switch (removeChoice)
        {
            case 1:
                Console.Write("Which item would you like to remove? Please enter the numer: ");
                int itemIndex = int.Parse(Console.ReadLine());

                if (itemIndex > 0 && itemIndex <= _currentOrder.Count)
                {
                    _currentOrder.RemoveAt(itemIndex - 1);
                    Console.WriteLine("Item has been removed from cart");
                }

                break;

            case 2:
                Console.Write("Which item would you like to adjust? Please enter the number: ");
                int adjustIndex = int.Parse(Console.ReadLine());

                if (adjustIndex > 0 && adjustIndex <= _currentOrder.Count)
                {
                    Console.Write("Enter the new quantity: ");
                    int newQuantity = int.Parse(Console.ReadLine());

                    if (newQuantity > 0)
                    {
                        _currentOrder[adjustIndex - 1].SetQuantity(newQuantity);
                        Console.WriteLine("Quantity has been updated. ");
                    }

                    else
                    {
                        Console.WriteLine("Quantity must be greater than 0. ");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid item number. ");
                }
                break; 
        }
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