using System;
using System.Globalization;
using Coin_Jar.API.Controllers;
using Coin_Jar.API.Interfaces;
using Coin_Jar.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Coin_Jar.Tests.Controllers
{
    [TestFixture]
    public class CoinsControllerTests
    {
        [Test]
        public void Given_CoinsController_When_ProcessCoin_Valid_Input_Then_Expect_Status_Ok()
        {
            const decimal amount = 0.50m;
            const decimal volume = 0.38m;
            var coinRequest = new CoinRequest
            {
                Amount = amount
            };
            var mockCoinManager = new Mock<ICoinManager>();
            var coin = new Coin {Amount = amount, Volume = volume};
            mockCoinManager.Setup(o => o.ProcessCoin(amount)).Returns(coin).Verifiable();

            var coinsController = new CoinsController(mockCoinManager.Object);
            var actionResult = coinsController.AddCoin(coinRequest);

            Assert.IsNotNull(actionResult);

            var okObjectResult = actionResult as OkObjectResult;

            Assert.IsNotNull(okObjectResult);
            Assert.That(() => okObjectResult.StatusCode == StatusCodes.Status200OK);

            var coinResponse = okObjectResult.Value as Coin;
            Assert.IsNotNull(coinResponse);
            Assert.That(() => coinResponse.Amount == amount);
            Assert.That(() => coinResponse.Volume == volume);

            mockCoinManager.Verify(o => o.ProcessCoin(amount), Times.Once);
        }

        [Test]
        public void Given_CoinsController_When_ProcessCoin_Invalid_Input_Then_Expect_Status_BadRequest()
        {
            const string invalidCurrencyAmount =
                "Invalid currency amount. Accepted amounts are 0.01, 0.05, 0.10, 0.25, 0.50, 1";
            const decimal amount = 0.50m;
            var coinRequest = new CoinRequest
            {
                Amount = amount
            };
            var mockCoinManager = new Mock<ICoinManager>();
            mockCoinManager.Setup(o => o.ProcessCoin(amount)).Returns(() => throw new Exception(
                invalidCurrencyAmount)).Verifiable();

            var coinsController = new CoinsController(mockCoinManager.Object);
            var actionResult = coinsController.AddCoin(coinRequest);

            Assert.IsNotNull(actionResult);

            var badRequestObjectResult = actionResult as BadRequestObjectResult;

            Assert.IsNotNull(badRequestObjectResult);
            Assert.That(() => badRequestObjectResult.StatusCode == StatusCodes.Status400BadRequest);
            Assert.That(() => badRequestObjectResult.Value.ToString() == invalidCurrencyAmount);

            mockCoinManager.Verify(o => o.ProcessCoin(amount), Times.Once);
        }

        [Test]
        public void Given_CoinsController_When_GetTotalAmount_Then_Expect_Status_Ok()
        {
            const decimal amount = 0.50m;
            var currencyAmount = amount.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            var mockCoinManager = new Mock<ICoinManager>();
            mockCoinManager.Setup(o => o.GetTotalAmount()).Returns(amount).Verifiable();

            var coinsController = new CoinsController(mockCoinManager.Object);

            var actionResult = coinsController.GetTotalAmount();

            Assert.IsNotNull(actionResult);

            var okObjectResult = actionResult as OkObjectResult;

            Assert.IsNotNull(okObjectResult);
            Assert.That(() => okObjectResult.StatusCode == StatusCodes.Status200OK);

            var coinResponse = okObjectResult.Value as TotalAmountResponse;
            Assert.IsNotNull(coinResponse);
            Assert.That(() => coinResponse.Amount == currencyAmount);

            mockCoinManager.Verify(o => o.GetTotalAmount(), Times.Once);
        }

        [Test]
        public void Given_CoinsController_When_Reset_Then_Expect_Status_NoContent()
        {
            var mockCoinManager = new Mock<ICoinManager>();
            mockCoinManager.Setup(o => o.Reset()).Verifiable();

            var coinsController = new CoinsController(mockCoinManager.Object);

            var actionResult = coinsController.Reset();

            Assert.IsNotNull(actionResult);

            var noContentResult = actionResult as NoContentResult;

            Assert.IsNotNull(noContentResult);
            Assert.That(() => noContentResult.StatusCode == StatusCodes.Status204NoContent);

            mockCoinManager.Verify(o => o.Reset(), Times.Once);
        }
    }
}