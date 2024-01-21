using BeautyClinicApi.Interfaces;
using BeautyClinicApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailController(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        [HttpGet]
        public IActionResult GetAllOrderDetails()
        {
            return Ok(_orderDetailRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetailById(int id)
        {
            var orderDetail = _orderDetailRepository.GetById(id);
            if (orderDetail == null) return NotFound();
            return Ok(orderDetail);
        }

        [HttpPost]
        public IActionResult CreateOrderDetail([FromBody] OrderDetail orderDetail)
        {
            _orderDetailRepository.Add(orderDetail);
            return CreatedAtAction(nameof(GetOrderDetailById), new { id = orderDetail.OrderDetailId }, orderDetail);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderDetail(int id, [FromBody] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailId) return BadRequest();
            _orderDetailRepository.Update(orderDetail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            _orderDetailRepository.Delete(id);
            return NoContent();
        }

    }
}
