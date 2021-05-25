using System.ComponentModel.DataAnnotations;

namespace Coin_Jar.API.Models
{
    public class CoinRequest
    {
        [Required]
        public decimal Amount { get; set; }
    }
}