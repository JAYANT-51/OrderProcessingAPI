using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingAPI.Models;
using OrderProcessingAPI.Services;

namespace OrderProcessingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }

        [HttpPost]
        public IActionResult ProcessOrder([FromBody] Order order)
        {
            if (order == null || string.IsNullOrEmpty(order.CustomerType) || order.OrderAmount <= 0)
            {
                return BadRequest("Invalid order details.");
            }

            decimal discount = _orderService.CalculateDiscount(order);
            decimal finalAmount = order.OrderAmount - discount;

            return Ok(new { Discount = discount, FinalAmount = finalAmount });
        }
    }
}
