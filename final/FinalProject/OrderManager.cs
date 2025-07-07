public class OrderManager
{
    private List<Food> _currentOrder;

    public void ViewShopMenu()
    {
        Console.WriteLine("These are our available stores: ");

        Console.WriteLine("1. Tandoori Delights -- Arabian Cuisine ");
        Console.WriteLine("2. Masala Palace -- Indian Cuisine ");

        Console.WriteLine("Which shop would you like to view? ");

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

    }

    public void ViewCart()
    {
        foreach (var food in _currentOrder)
        {
            food.ShowFoodDetailsForOrder();
        }
    }

    public void RemoveFromCart()
    {

    }

    public void DeleteCart()
    {

    }

    public void ConfirmOrder()
    {

    }
}