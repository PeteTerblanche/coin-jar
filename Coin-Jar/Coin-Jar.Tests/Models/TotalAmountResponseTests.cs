using Coin_Jar.API.Models;
using NUnit.Framework;

namespace Coin_Jar.Tests.Models
{
    [TestFixture]
    public class TotalAmountResponseTests
    {
        [Test]
        public void Given_TotalAmountResponse_When_Amount_Set_Then_Expect_Amount_Returned()
        {
            const string expectedAmount = "1";

            var coin = new TotalAmountResponse
            {
                Amount = expectedAmount
            };

            Assert.AreEqual(expectedAmount, coin.Amount);
        }
    }
}