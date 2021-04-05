using System;
using System.Linq;
using System.Collections.Generic;
using VendingMachine.Model;
using VendingMachine.Dto;

namespace VendingMachine
{
    public class AcceptCoins
    {
        public static double TotalMoney { get; set; }
        public static List<Coin> Coins { get; set; }

        public static void AcceptCoin(int numberOfCoins)
        {
            List<Coin> coins = new List<Coin>();
            for (int i = 0; i < numberOfCoins; i++)
            {
                Console.WriteLine($".....Enter the Weight of coin(in gms) {i + 1}:  ");
                string weight = Console.ReadLine();
                Console.WriteLine($".....Enter the Thickness of coin(in mm) {i + 1}:  ");
                string thickness = Console.ReadLine();
                double w;
                double t;
                if (!double.TryParse(weight, out w))
                {
                    Console.WriteLine("Invalid weight Value , enter the just the number");
                }
                else if (!double.TryParse(thickness, out t))
                {
                    Console.WriteLine("Invalid Thickness of the coin, ignoring the coin");
                }
                else
                {
                    CoinDimension coin = new CoinDimension
                    {
                        Thickness = t,
                        Weight = w
                    };
                    coins.Add(new Coin(coin));
                }
            }
            if (Coins == null || Coins.Count < 0)
                Coins = coins;
            else
                Coins.AddRange(coins);
            TotalMoney = Math.Round(Coins.Select(s => s.Value).Sum(), 2);
            Console.WriteLine($"TotalMoney = {TotalMoney}");
        }
    }
}
