using Coin_Jar.API.Interfaces;

namespace Coin_Jar.API.Models
{
    public class Coin : ICoin
    {
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
    }
}