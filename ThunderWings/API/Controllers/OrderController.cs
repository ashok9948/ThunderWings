using Microsoft.AspNetCore.Mvc; 
using ThunderWings.Application.Services; 

namespace ThunderWings.API.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class OrderController : ControllerBase // Inherit from ControllerBase
    {
        private readonly OrderService _orderService; // Define a private readonly field for OrderService

        // Constructor to inject OrderService
        public OrderController(OrderService orderService)
        {
            _orderService = orderService; // Assign the injected service to the private field
        }

        // Define an HTTP POST method for checkout
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequest request)
        {
            try
            {
                // Attempt to create an order and retrieve the orderId
                var orderId = await _orderService.CreateOrderAsync(request.CustomerId);
                return Ok(new { OrderId = orderId }); // Return the orderId in the response
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return a bad request with the error message in case of exception
            }
        }
    }

    // Define a class for the checkout request payload
    public class CheckoutRequest
    {
        public string CustomerId { get; set; } // Property to hold the CustomerId
    }
}
