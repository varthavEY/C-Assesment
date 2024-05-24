using System;
using System.Collections.Generic;

class Program
{
    static string registeredUsername = "varthav"; // hardcoded username
    static string registeredPassword = "12345";   // hardcoded password

    static Dictionary<string, (string Name, int Price, int Quantity)> products = new Dictionary<string, (string, int, int)>
    {
        { "1", ("Chips", 20, 0) },
        { "2", ("Soda", 40, 0) },
        { "3", ("Ice Cream", 30, 0) },
        { "4", ("Chocolate", 10, 0) }
    };

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Welcome to the eCommerce System");
            Console.WriteLine();

            Console.WriteLine("1. Login");
            Console.WriteLine();

            Console.WriteLine("2. Register");
            Console.WriteLine();

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SignIn();
                    break;

                case "2":
                    SignUp();
                    break;

                default:
                    Console.WriteLine("Wrong Option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void SignIn()
    {
        Console.Clear();

        Console.Write("Enter the Username: ");
        Console.WriteLine();

        string username = Console.ReadLine();
        Console.Write("Enter the Password: ");
        Console.WriteLine();

        string password = Console.ReadLine();

        if (username == registeredUsername && password == registeredPassword)
        {
            ShowProducts();
        }

        else
        {
            Console.WriteLine("Invalid credentials. Press any key to return.");
            Console.ReadKey();
        }
    }

    static void SignUp()
    {
        Console.Clear();

        Console.Write("Enter new Username: ");
        Console.WriteLine();
        registeredUsername = Console.ReadLine();

        Console.Write("Enter new Password: ");
        Console.WriteLine();
        registeredPassword = Console.ReadLine();

        Console.WriteLine("Registered. Press any key to return.");
        Console.ReadKey();
    }

    static void ShowProducts()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Here are the List of Products:");
            Console.WriteLine();

            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Key}, Name: {product.Value.Name}, Price: ${product.Value.Price}, Quantity in Cart: {product.Value.Quantity}");
            }

            Console.WriteLine();
            Console.Write("Enter product ID number to add to cart or 'c' to checkout/continue: ");

            string productChoice = Console.ReadLine();

            if (productChoice.Equals("c", StringComparison.OrdinalIgnoreCase))
            {
                ShowCart();
                return;
            }

            else if (products.ContainsKey(productChoice))
            {
                Console.Write($"Enter quantity for {products[productChoice].Name}: ");
                if (int.TryParse(Console.ReadLine(), out int quantity))
                {
                    var product = products[productChoice];
                    product.Quantity += quantity;
                    products[productChoice] = product;
                }

                else
                {
                    Console.WriteLine("Invalid quantity. Press any key to return.");
                    Console.ReadKey();
                }
            }

            else
            {
                Console.WriteLine("Invalid product ID. Press any key to return.");
                Console.ReadKey();
            }
        }
    }

    static void ShowCart()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Cart:");

            int totalCost = 0;

            foreach (var product in products)
            {
                if (product.Value.Quantity > 0)
                {
                    int cost = product.Value.Price * product.Value.Quantity;
                    Console.WriteLine($"{product.Value.Name}: {product.Value.Quantity} x ${product.Value.Price} = ${cost}");
                    totalCost += cost;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Total Cost: ${totalCost}");

            Console.WriteLine();
            Console.WriteLine("1. Checkout");

            Console.WriteLine();
            Console.WriteLine("2. Return to products menu");

            Console.WriteLine();
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Checkout(totalCost);
                    return;

                case "2":
                    ShowProducts();
                    return;

                default:
                    Console.WriteLine("Wrong option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void Checkout(int totalCost)
    {
        Console.Clear();

        Console.WriteLine("Final Cart:");
        Console.WriteLine();

        foreach (var product in products)
        {
            if (product.Value.Quantity > 0)
            {
                Console.WriteLine($"{product.Value.Name}: {product.Value.Quantity}");
            }
        }
        Console.WriteLine($"Total cost: ${totalCost}");
        Console.WriteLine();

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();

        Environment.Exit(0);
    }
}
