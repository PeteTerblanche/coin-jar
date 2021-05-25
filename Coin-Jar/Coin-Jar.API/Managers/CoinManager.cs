using System;
using System.Collections.Generic;
using System.Linq;
using Coin_Jar.API.Interfaces;
using Coin_Jar.API.Models;

namespace Coin_Jar.API.Managers
{
    /// <summary>
    /// ref: https://www.usmint.gov/learn/coin-and-medal-programs/coin-specifications
    /// </summary>
    public class CoinManager : ICoinManager
    {
        private readonly ICoinJar _coinJar;

        private readonly List<Coin> _coinTypes = new List<Coin>
        {
            new Coin{ Amount = 0.01m, Volume = 0.08m }, // Cent
            new Coin{ Amount = 0.05m, Volume = 0.17m }, // Nickel
            new Coin{ Amount = 0.10m, Volume = 0.08m }, // Dime
            new Coin{ Amount = 0.25m, Volume = 0.19m }, // Quarter Dollar
            new Coin{ Amount = 0.50m, Volume = 0.38m }, // Half Dollar
            new Coin{ Amount = 1m, Volume = 0.27m } // Dollar
        };

        public CoinManager(ICoinJar coinJar)
        {
            _coinJar = coinJar;
        }

        public ICoin ProcessCoin(decimal amount)
        {
            var type = _coinTypes.FirstOrDefault(c => c.Amount == amount);

            if (type is null)
            {
                throw new Exception("Invalid currency amount. Accepted amounts are 0.01, 0.05, 0.10, 0.25, 0.50, 1");
            }

            var coin = new Coin
            {
                Amount = type.Amount,
                Volume = type.Volume
            };
            _coinJar.AddCoin(coin);
            return coin;
        }

        public decimal GetTotalAmount()
        {
            return _coinJar.GetTotalAmount();
        }

        public void Reset()
        {
            _coinJar.Reset();
        }
    }
}