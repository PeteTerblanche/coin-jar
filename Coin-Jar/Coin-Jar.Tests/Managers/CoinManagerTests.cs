using Coin_Jar.API.Interfaces;
using Coin_Jar.API.Managers;
using Coin_Jar.API.Models;
using Moq;
using NUnit.Framework;

namespace Coin_Jar.Tests.Managers
{
    [TestFixture]
    public class CoinManagerTests
    {
        [Test]
        public void Given_CoinManager_When_Process_Cent_Coin_Then_Expect_Cent_Coin_Returned()
        {
            const decimal expectedAmount = 0.01m;
            const decimal expectedVolume = 0.08m;
            var expectedCoin = new Coin
            {
                Amount = expectedAmount,
                Volume = expectedVolume
            };

            var mockCoinJar = new Mock<ICoinJar>();
            mockCoinJar.Setup(o => o.AddCoin(expectedCoin)).Verifiable();

            var coinManager = new CoinManager(mockCoinJar.Object);

            var coin = coinManager.ProcessCoin(expectedAmount);

            Assert.That(() => coin.Amount == expectedAmount);
            Assert.That(() => coin.Volume == expectedVolume);
            mockCoinJar.Verify(o => o.AddCoin(coin), Times.Once);
        }

        [Test]
        public void Given_CoinManager_When_Process_Nickel_Coin_Then_Expect_Nickel_Coin_Returned()
        {
            const decimal expectedAmount = 0.05m;
            const decimal expectedVolume = 0.17m;
            var expectedCoin = new Coin
            {
                Amount = expectedAmount,
                Volume = expectedVolume
            };

            var mockCoinJar = new Mock<ICoinJar>();
            mockCoinJar.Setup(o => o.AddCoin(expectedCoin)).Verifiable();

            var coinManager = new CoinManager(mockCoinJar.Object);

            var coin = coinManager.ProcessCoin(expectedAmount);

            Assert.That(() => coin.Amount == expectedAmount);
            Assert.That(() => coin.Volume == expectedVolume);
            mockCoinJar.Verify(o => o.AddCoin(coin), Times.Once);
        }

        [Test]
        public void Given_CoinManager_When_Process_Dime_Coin_Then_Expect_Dime_Coin_Returned()
        {
            const decimal expectedAmount = 0.10m;
            const decimal expectedVolume = 0.08m;
            var expectedCoin = new Coin
            {
                Amount = expectedAmount,
                Volume = expectedVolume
            };

            var mockCoinJar = new Mock<ICoinJar>();
            mockCoinJar.Setup(o => o.AddCoin(expectedCoin)).Verifiable();

            var coinManager = new CoinManager(mockCoinJar.Object);

            var coin = coinManager.ProcessCoin(expectedAmount);

            Assert.That(() => coin.Amount == expectedAmount);
            Assert.That(() => coin.Volume == expectedVolume);
            mockCoinJar.Verify(o => o.AddCoin(coin), Times.Once);
        }

        [Test]
        public void Given_CoinManager_When_Process_Quarter_Coin_Then_Expect_Quarter_Coin_Returned()
        {
            const decimal expectedAmount = 0.25m;
            const decimal expectedVolume = 0.19m;
            var expectedCoin = new Coin
            {
                Amount = expectedAmount,
                Volume = expectedVolume
            };

            var mockCoinJar = new Mock<ICoinJar>();
            mockCoinJar.Setup(o => o.AddCoin(expectedCoin)).Verifiable();

            var coinManager = new CoinManager(mockCoinJar.Object);

            var coin = coinManager.ProcessCoin(expectedAmount);

            Assert.That(() => coin.Amount == expectedAmount);
            Assert.That(() => coin.Volume == expectedVolume);
            mockCoinJar.Verify(o => o.AddCoin(coin), Times.Once);
        }

        [Test]
        public void Given_CoinManager_When_Process_HalfDollar_Coin_Then_Expect_HalfDollar_Coin_Returned()
        {
            const decimal expectedAmount = 0.50m;
            const decimal expectedVolume = 0.38m;
            var expectedCoin = new Coin
            {
                Amount = expectedAmount,
                Volume = expectedVolume
            };

            var mockCoinJar = new Mock<ICoinJar>();
            mockCoinJar.Setup(o => o.AddCoin(expectedCoin)).Verifiable();

            var coinManager = new CoinManager(mockCoinJar.Object);

            var coin = coinManager.ProcessCoin(expectedAmount);

            Assert.That(() => coin.Amount == expectedAmount);
            Assert.That(() => coin.Volume == expectedVolume);
            mockCoinJar.Verify(o => o.AddCoin(coin), Times.Once);
        }

        [Test]
        public void Given_CoinManager_When_Process_Dollar_Coin_Then_Expect_Dollar_Coin_Returned()
        {
            const decimal expectedAmount = 1m;
            const decimal expectedVolume = 0.27m;
            var expectedCoin = new Coin
            {
                Amount = expectedAmount,
                Volume = expectedVolume
            };

            var mockCoinJar = new Mock<ICoinJar>();
            mockCoinJar.Setup(o => o.AddCoin(expectedCoin)).Verifiable();

            var coinManager = new CoinManager(mockCoinJar.Object);

            var coin = coinManager.ProcessCoin(expectedAmount);

            Assert.That(() => coin.Amount == expectedAmount);
            Assert.That(() => coin.Volume == expectedVolume);
            mockCoinJar.Verify(o => o.AddCoin(coin), Times.Once);
        }

        [Test]
        public void Given_CoinManager_When_Process_Invalid_Coin_Then_Expect_Exception()
        {
            const string errMsg = "Invalid currency amount. Accepted amounts are 0.01, 0.05, 0.10, 0.25, 0.50, 1";
            const decimal invalidAmount = 0.99m;

            var mockCoinJar = new Mock<ICoinJar>();
            mockCoinJar.Setup(o => o.AddCoin(It.IsAny<ICoin>())).Verifiable();

            var coinManager = new CoinManager(mockCoinJar.Object);

            Assert.That(() => coinManager.ProcessCoin(invalidAmount), Throws.Exception.With.Message.EqualTo(errMsg));
            mockCoinJar.Verify(o => o.AddCoin(It.IsAny<ICoin>()), Times.Never);
        }

        [Test]
        public void Given_CoinManager_When_GetTotalAmount_Then_Expect_CoinJar_GetTotalAmount_Called()
        {
            const decimal amount = 10.50m;
            var mockCoinJar = new Mock<ICoinJar>();
            mockCoinJar.Setup(o => o.GetTotalAmount()).Returns(amount).Verifiable();

            var coinManager = new CoinManager(mockCoinJar.Object);

            Assert.That(() => coinManager.GetTotalAmount() == amount);
            mockCoinJar.Verify(o => o.GetTotalAmount(), Times.Once);
        }

        [Test]
        public void Given_CoinManager_When_Reset_Then_Expect_CoinJar_Reset_Called()
        {
            var mockCoinJar = new Mock<ICoinJar>();
            mockCoinJar.Setup(o => o.Reset()).Verifiable();

            var coinManager = new CoinManager(mockCoinJar.Object);

            coinManager.Reset();

            mockCoinJar.Verify(o => o.Reset(), Times.Once);
        }
    }
}