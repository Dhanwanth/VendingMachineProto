using System;
namespace VendingMachine
{
    public class StaticStrings
    {
        public static void MainMenu()
        {
            Console.WriteLine("..................................................................................................... \n\n");
            Console.WriteLine("        Choose one of the below option(select a number and hit enter");
            Console.WriteLine("        1. Insert Coins");
            Console.WriteLine("        2. Choose a product");
            Console.WriteLine("..................................................................................................... \n\n");
        }

        public static void DisplayCoins()
        {
            Console.WriteLine("    Reference: https://www.usmint.gov/learn/coin-and-medal-programs/coin-specifications");
            Console.WriteLine("    Nickel" +
                "\n        Value => (1/20 $) " +
                "\n        Weight => (5 g)" +
                "\n        Thickness => (1.95 mm)");
            Console.WriteLine("    Dime" +
                "\n        Value => (1/10 $) " +
                "\n        Weight => (2.27 g)" +
                "\n        Thickness => (1.35 mm)");
            Console.WriteLine("    Quarter" +
                "\n        Value => (1/4 $) " +
                "\n        Weight => (5.67 g)" +
                "\n        Thickness => (1.75 mm)");
        }

        public static void WriteHeaders()
        {
            Console.WriteLine("\n ................................................................................................... \n");
            Console.WriteLine("  This Vending machine assumes that user enter the dimensions of the coins to insert the coin");
            Console.WriteLine("  The size of the coins are given below for reference");
            Console.WriteLine("..................................................................................................... \n\n");
        }
    }
}
