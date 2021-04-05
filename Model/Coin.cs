using System;
using VendingMachine.Dto;
namespace VendingMachine.Model
{
    
    public class Coin
    {
        public double Value { get; private init; }
        public CoinType CoinType { get; private init; }
        public CoinDimension CoinDimension { get; init; }

        public Coin(CoinDimension coinDimension)
        {
            this.CoinDimension = coinDimension;
            this.CoinType = getType(coinDimension);
            this.Value = getValue(this.CoinType);
            
        }
        private CoinType getType(CoinDimension coin)
        {
            if (coin.Weight == 5 && coin.Thickness == 1.95)
                return CoinType.Nickel;
            else if (coin.Weight == 2.27 && coin.Thickness == 1.35)
                return CoinType.Dimes;
            else if (coin.Weight == 5.67 && coin.Thickness == 1.75)
                return CoinType.Quarters;
            else
                return CoinType.Others;
        }
        private double getValue(CoinType coinType)
        {
            switch(coinType)
            {
                case CoinType.Dimes:
                    return 0.1;
                case CoinType.Nickel:
                    return 0.05;
                case CoinType.Quarters:
                    return 0.25;
                default: return 0;
            }
        }
    }
}
