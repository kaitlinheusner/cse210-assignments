using System;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Welcome to the Online Food Shopping Program! ");
        Console.WriteLine();

        OrderManager orderManager = new OrderManager();

        int userChoice = 0;

        while (userChoice != 7)
        {
            Console.WriteLine("1. View Menu");
            Console.WriteLine("2. Add to Cart");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Remove from Cart");
            Console.WriteLine("5. Delete Cart");
            Console.WriteLine("6. Confirm Order");
            Console.WriteLine("7. Quit Shopping Program");

            Console.Write("Which would you like to do? ");
            userChoice = int.Parse(Console.ReadLine());

            Console.WriteLine();

            switch (userChoice)
            {
                case 1:
                    orderManager.ViewShopMenu();
                    Console.WriteLine();
                    break;

                case 2:
                    orderManager.AddToCart();
                    Console.WriteLine();
                    break;

                case 3:
                    orderManager.ViewCart();
                    Console.WriteLine();
                    break;

                case 4:
                    orderManager.RemoveFromCart();
                    Console.WriteLine();
                    break;

                case 5:
                    orderManager.DeleteCart();
                    Console.WriteLine();
                    break;

                case 6:
                    orderManager.ConfirmOrder();
                    Console.WriteLine();
                    break;

                case 7:
                    break;
            }
        }
    }
}