using Microsoft.AspNetCore.Mvc;
using ThunderWings.Application.Services;

namespace ThunderWings.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly BasketService _basketService;

        public BasketController(BasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetBasket(string customerId)
        {
            var basket = await _basketService.GetBasketAsync(customerId);
            return Ok(basket);
        }

        [HttpPost("{customerId}/add")]
        public async Task<IActionResult> AddToBasket(string customerId, [FromBody] AddToBasketRequest request)
        {
            await _basketService.AddToBasketAsync(customerId, request.AircraftId, request.Quantity);
            return Ok();
        }

        [HttpPost("{customerId}/remove")]
        public async Task<IActionResult> RemoveFromBasket(string customerId, [FromBody] RemoveFromBasketRequest request)
        {
            await _basketService.RemoveFromBasketAsync(customerId, request.AircraftId);
            return Ok();
        }
    }

    public class AddToBasketRequest
    {
        public int AircraftId { get; set; }
        public int Quantity { get; set; }
    }

    public class RemoveFromBasketRequest
    {
        public int AircraftId { get; set; }
    }
}