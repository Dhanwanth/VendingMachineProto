using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Model;

namespace VendingMachine
{
    public class Program
    {
        private static double totalMoney { get; set; }
        private static List<Coin> Coins { get; set; }

        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Vending Machine!");
            StaticStrings.WriteHeaders();
            StaticStrings.DisplayCoins();
            Console.WriteLine($"Total Money(Credited) = {totalMoney}");

            var choice = ReadChoice();
            if (choice == 1)
            {
                StaticStrings.DisplayCoins();
                int numberOfCoins = ReadCoins();
                AcceptCoins.AcceptCoin(numberOfCoins);
                totalMoney = AcceptCoins.TotalMoney;
                Coins = AcceptCoins.Coins;
                Main();
            }
            else if(choice == 2)
            {
                int product = ReadProductChoice();
                Console.WriteLine("Vending Done!!!");
                Main();
            }
        }
       
        private static int ReadCoins()
        {
            Console.WriteLine("    ....Enter number of coins: ");
            var numberOfCoins = Utils.CheckForInteger(Console.ReadLine(),ReadCoins);
            return numberOfCoins;
        }

        private static int ReadProductChoice()
        {
            Console.Clear();
            int i = 1;
            Console.WriteLine($"        Total Money Left = {totalMoney} ");
            Console.WriteLine("........Pick Product..........");
            var products = ReadProducts.readProducts().ConfigureAwait(false).GetAwaiter().GetResult();
            foreach (var product in products.products)
            {
                Console.WriteLine($"    .......{i}. {product.Key} (Price => {product.Value.price})");
                i++;
            }
            var readProduct = Console.ReadLine();
            int choice = Utils.CheckForInteger(readProduct, ReadProductChoice);
            choice = Utils.CheckChoice(choice, i-1, ReadProductChoice);
            var product1 = products.products.ElementAt(choice - 1);
            Console.WriteLine($"Selected Product = {product1.Key}");
            Console.WriteLine($"Selected Product Price = {product1.Value.price}");
            if (totalMoney < product1.Value.price)
                Console.WriteLine("....Money Not Enough, please insert more coins");
            else
            {
                Console.WriteLine($"Product dispensed successfully.......{product1.Key}");
                totalMoney = totalMoney - product1.Value.price;
                Coins = new List<Coin>();
                AcceptCoins.TotalMoney = totalMoney;
                AcceptCoins.Coins = Coins;
                Console.WriteLine($"Remaining Amount: {totalMoney}");
            }
            return choice;
        }

        private static int ReadChoice()
        {
            StaticStrings.MainMenu();
            var input = Console.ReadLine();
            int choice = Utils.CheckForInteger(input, ReadChoice);
            choice = Utils.CheckChoice(choice, 2, ReadChoice);
            return choice;
        }

    }
}
