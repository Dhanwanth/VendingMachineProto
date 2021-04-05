using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VendingMachine.Model;
using VendingMachine.Dto;

namespace VendingMachine
{
    class Program
    {
        private static double totalMoney { get; set; }
        private static List<Coin> Coins { get; set; }

        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Vending Machine!");
            WriteHeaders();
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
            var numberOfCoins = CheckForInteger(Console.ReadLine(),ReadCoins);
            return numberOfCoins;
        }

        private static int ReadProductChoice()
        {
            Console.Clear();
            int i = 1;
            Console.WriteLine($"        Total Money Left = {totalMoney} ");
            Console.WriteLine("........Pick Product..........");
            var products = readProducts().ConfigureAwait(false).GetAwaiter().GetResult();
            foreach (var product in products.products)
            {
                Console.WriteLine($"    .......{i}. {product.Key} (Price => {product.Value.price})");
                i++;
            }
            var readProduct = Console.ReadLine();
            int choice = CheckForInteger(readProduct, ReadProductChoice);
            choice = CheckChoice(choice, i-1, ReadProductChoice);
            var product1 = products.products.ElementAt(choice - 1);
            Console.WriteLine($"Selected Product = {product1.Key}");
            Console.WriteLine($"Selected Product Price = {product1.Value.price}");
            if (totalMoney < product1.Value.price)
                Console.WriteLine("....Money Not Enough, please insert more coins");
            else
            {
                Console.WriteLine($"Product dispensed successfully.......{product1.Key}");
                totalMoney = totalMoney - product1.Value.price;
                Console.WriteLine($"Remaining Amount: {totalMoney}");
            }
            return choice;
        }

        private static async Task<Products> readProducts()
        {
            string json = string.Empty;
            using(StreamReader str = new StreamReader("./products.json"))
            {
                json = await str.ReadToEndAsync();
            }
            var products = JsonConvert.DeserializeObject<Products>(json);
            return products;
        }
        private static void WriteHeaders()
        {
            Console.WriteLine("\n ................................................................................................... \n");
            Console.WriteLine("  This Vending machine assumes that user enter the dimensions of the coins to insert the coin");
            Console.WriteLine("  The size of the coins are given below for reference");
            Console.WriteLine("..................................................................................................... \n\n");
        }

        private static int ReadChoice()
        {
            Console.WriteLine("..................................................................................................... \n\n");
            Console.WriteLine("        Choose one of the below option(select a number and hit enter");
            Console.WriteLine("        1. Insert Coins");
            Console.WriteLine("        2. Choose a product");
            Console.WriteLine("..................................................................................................... \n\n");
            var input = Console.ReadLine();
            int choice = CheckForInteger(input, ReadChoice);
            choice = CheckChoice(choice,2,ReadChoice);
            return choice;
        }

        public static int CheckChoice(int choice, int numberOfChoices, Func<int> func)
        {
            if (choice < 1 || choice > numberOfChoices)
            {
                Console.Clear();
                Console.WriteLine("   ....Error Reading Input please enter a valid choice and try again...");
                choice = func();
            }

            return choice;
        }

        public static int CheckForInteger(string input, Func<int> func)
        {
            if (!Int32.TryParse(input, out var choice))
            {
                Console.Clear();
                Console.WriteLine("   ....Error Reading Input please enter valid input, try again...");
                choice = func();
            }
            else if(choice <= 0)
            {
                Console.WriteLine("... Not a valid choice");
                choice = func();
            }
            return choice;
        }
    }
}
