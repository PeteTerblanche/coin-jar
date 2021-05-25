using Coin_Jar.API.Models;
using NUnit.Framework;

namespace Coin_Jar.Tests.Models
{
    [TestFixture]
    public class CoinJarTests
    {
        [Test]
        public void Given_AddCoin_When_Coin_Validation_Pass_Then_Expect_Coin_Added()
        {
            var coinJar = new CoinJar();
            coinJar.AddCoin(new Coin {Amount = 1, Volume = 1});

            Assert.IsNotNull(coinJar.Coins);
            Assert.That(() => coinJar.Coins.Count == 1);
            Assert.That(() => coinJar.Coins[0].Amount == 1);
            Assert.That(() => coinJar.Coins[0].Volume == 1);
        }

        [Test]
        public void Given_AddCoin_When_MaxVolume_Exceeded_Then_Expect_Exception()
        {
            const decimal total = 42.01m;
            var errMsg = $"Current volume is {total} ounces. Maximum of 42 ounces accepted.";

            var coin = new Coin {Amount = 500m, Volume = 42.01m};
            var coinJar = new CoinJar();
            coinJar.Coins.Add(coin);

            Assert.That(() => coinJar.AddCoin(coin), Throws.Exception.With.Message.EqualTo(errMsg));
        }

        [Test]
        public void Given_AddCoin_When_GetTotalAmount_Then_Expect_Total_Returned()
        {
            var coinJar = new CoinJar();
            coinJar.AddCoin(new Coin {Amount = 15, Volume = 15});

            Assert.That(() => coinJar.Coins != null);
            Assert.That(() => coinJar.GetTotalAmount() == 15);
        }

        [Test]
        public void CoinJar_AddCoin_Reset_Then_Expect_Coins_Cleared()
        {
            var coinJar = new CoinJar();
            coinJar.AddCoin(new Coin {Amount = 15, Volume = 15});

            Assert.That(() => coinJar.Coins != null);
            Assert.That(() => coinJar.GetTotalAmount() == 15);

            coinJar.Reset();

            Assert.That(() => coinJar.GetTotalAmount() == 0);
        }
    }
}