using System;
using System.Collections.Generic;
using System.Linq;
using Coin_Jar.API.Interfaces;

namespace Coin_Jar.API.Models
{
    public class CoinJar :ICoinJar
    {
        private const decimal MAX_FLUID_OUNCE = 42;
        public List<ICoin> Coins { get; } = new List<ICoin>();
        public void AddCoin(ICoin coin)
        {
            var tempCoins = new List<ICoin>(Coins) {coin};
            var currentVolume = tempCoins.Sum(c => c.Volume);
            if (currentVolume > MAX_FLUID_OUNCE)
            {
                var totalVolume = GetTotalVolume();
                throw new Exception($"Current volume is {totalVolume} ounces. Maximum of {MAX_FLUID_OUNCE} ounces accepted.");
            }

            Coins.Add(coin);
        }

        private decimal GetTotalVolume() => Coins.Sum(coin => coin.Volume);
        public decimal GetTotalAmount() => Coins.Sum(coin => coin.Amount);
        public void Reset() => Coins.Clear();
    }
}