using Microsoft.AspNetCore.Mvc;
using ThunderWings.Application.Services;

namespace ThunderWings.API.Controllers
{
    // Indicates that this class is an API controller
    [ApiController]
    // Defines the route for this controller, e.g., api/Basket
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        // Service to handle basket operations
        private readonly BasketService _basketService;

        // Constructor to inject the BasketService dependency
        public BasketController(BasketService basketService)
        {
            _basketService = basketService;
        }

        // Endpoint to retrieve the basket for a specific customer
        // HTTP GET method: api/Basket/{customerId}
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetBasket(string customerId)
        {
            // Call the service to get the basket asynchronously
            var basket = await _basketService.GetBasketAsync(customerId);
            // Return the basket with a 200 OK status
            return Ok(basket);
        }

        // Endpoint to add an item to the basket for a specific customer
        // HTTP POST method: api/Basket/{customerId}/add
        [HttpPost("{customerId}/add")]
        public async Task<IActionResult> AddToBasket(string customerId, [FromBody] AddToBasketRequest request)
        {
            // Call the service to add an item to the basket asynchronously
            await _basketService.AddToBasketAsync(customerId, request.AircraftId, request.Quantity);
            // Return a 200 OK status
            return Ok();
        }

        // Endpoint to remove an item from the basket for a specific customer
        // HTTP POST method: api/Basket/{customerId}/remove
        [HttpPost("{customerId}/remove")]
        public async Task<IActionResult> RemoveFromBasket(string customerId, [FromBody] RemoveFromBasketRequest request)
        {
            // Call the service to remove an item from the basket asynchronously
            await _basketService.RemoveFromBasketAsync(customerId, request.AircraftId);
            // Return a 200 OK status
            return Ok();
        }
    }

    // Request model for adding an item to the basket
    public class AddToBasketRequest
    {
        // ID of the aircraft to add
        public int AircraftId { get; set; }
        // Quantity of the aircraft to add
        public int Quantity { get; set; }
    }

    // Request model for removing an item from the basket
    public class RemoveFromBasketRequest
    {
        // ID of the aircraft to remove
        public int AircraftId { get; set; }
    }
}
