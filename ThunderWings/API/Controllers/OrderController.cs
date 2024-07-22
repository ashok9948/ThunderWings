using Microsoft.AspNetCore.Mvc;
using ThunderWings.Application.Services;

namespace ThunderWings.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequest request)
        {
            try
            {
                var orderId = await _orderService.CreateOrderAsync(request.CustomerId);
                return Ok(new { OrderId = orderId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    public class CheckoutRequest
    {
        public string CustomerId { get; set; }
    }
}