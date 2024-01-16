using Microsoft.AspNetCore.Mvc;
using BeautyClinicApi.Models;
using BeautyClinicApi.Interfaces;

namespace BeautyClinicApi.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]

    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok(_orderRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            _orderRepository.Add(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order order)
        {
            if (id != order.OrderId) return BadRequest();
            _orderRepository.Update(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetOrdersByUser(int userId)
        {
            var orders = _orderRepository.GetByUserId(userId);
            if (orders == null || !orders.Any()) return NotFound();
            return Ok(orders);
        }

        // GET api/order/date/{date}
        [HttpGet("date/{date}")]
        public IActionResult GetOrdersByDate(DateTime date)
        {
            var orders = _orderRepository.GetByDate(date);
            if (orders == null || !orders.Any()) return NotFound();
            return Ok(orders);
        }
    }
}
