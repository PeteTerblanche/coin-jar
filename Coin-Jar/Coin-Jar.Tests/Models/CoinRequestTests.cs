using Coin_Jar.API.Models;
using NUnit.Framework;

namespace Coin_Jar.Tests.Models
{
    [TestFixture]
    public class CoinRequestTests
    {
        [Test]
        public void Given_CoinRequest_When_Amount_Set_Then_Expect_Amount_Returned()
        {
            const int expectedAmount = 1;

            var coin = new CoinRequest
            {
                Amount = expectedAmount
            };

            Assert.AreEqual(expectedAmount, coin.Amount);
        }
    }
}