using System;
namespace VendingMachine
{
    public class StaticStrings
    {
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

    }
}
