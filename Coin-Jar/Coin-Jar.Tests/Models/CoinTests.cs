using Coin_Jar.API.Models;
using NUnit.Framework;

namespace Coin_Jar.Tests.Models
{
    [TestFixture]
    public class CoinTests
    {
        [Test]
        public void Given_Coin_When_Properties_Set_Then_Expect_Properties_Returned()
        {
            const int expectedAmount = 1;
            const decimal expectedVolume = 1;

            var coin = new Coin
            {
                Amount = expectedAmount,
                Volume = expectedVolume
            };

            Assert.AreEqual(expectedAmount, coin.Amount);
            Assert.AreEqual(expectedVolume, coin.Volume);
        }
    }
}