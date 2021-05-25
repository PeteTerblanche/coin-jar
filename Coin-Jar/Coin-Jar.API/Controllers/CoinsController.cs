using System;
using System.Globalization;
using Coin_Jar.API.Interfaces;
using Coin_Jar.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coin_Jar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoinsController : Controller
    {
        private readonly ICoinManager _coinManager;

        public CoinsController(ICoinManager coinManager)
        {
            _coinManager = coinManager;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Coin))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddCoin([FromBody]CoinRequest coinRequest)
        {
            try
            {
                var coin = _coinManager.ProcessCoin(coinRequest.Amount);
                return Ok(coin);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TotalAmountResponse))]
        public IActionResult GetTotalAmount()
        {
            var totalAmount = _coinManager.GetTotalAmount();
            var amount = totalAmount.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            return Ok(new TotalAmountResponse { Amount = amount });
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Reset()
        {
            _coinManager.Reset();
            return NoContent();
        }
    }
}