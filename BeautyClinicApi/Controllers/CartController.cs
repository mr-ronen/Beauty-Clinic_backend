using Microsoft.AspNetCore.Mvc;
using BeautyClinicApi.Interfaces;
using BeautyClinicApi.DTOs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BeautyClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Assuming you want the cart to be accessible only to authenticated users
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        // Get cart items for a user
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCartItems(int userId)
        {
            try
            {
                var cartItems = await _cartRepository.GetCartItems(userId);
                var cartItemDTOs = cartItems.Select(ci => new CartItemDTO
                {
                    CartItemId = ci.CartItemId,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    Price = ci.Price
                }).ToList();

                return Ok(cartItemDTOs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while retrieving the cart items.");
            }
        }

        // Add an item to the cart
        [HttpPost("add")]
        public async Task<IActionResult> AddItemToCart([FromBody] CartItemDTO cartItemDTO)
        {
            try
            {
                await _cartRepository.AddItem(cartItemDTO.UserId, cartItemDTO.ProductId, cartItemDTO.Quantity);
                return Ok("Item added to cart");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while adding the item to the cart.");
            }
        }

        // Remove an item from the cart
        [HttpDelete("remove/{cartItemId}")]
        public async Task<IActionResult> RemoveItemFromCart(int cartItemId)
        {
            try
            {
                await _cartRepository.RemoveItem(cartItemId);
                return Ok("Item removed from cart");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while removing the item from the cart.");
            }
        }

        // Update the quantity of a cart item
        [HttpPut("update/{cartItemId}")]
        public async Task<IActionResult> UpdateCartItem(int cartItemId, [FromBody] int quantity)
        {
            try
            {
                await _cartRepository.UpdateQuantity(cartItemId, quantity);
                return Ok("Cart item quantity updated");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while updating the cart item.");
            }
        }

        // Clear the cart
        [HttpPost("clear/{userId}")]
        public async Task<IActionResult> ClearUserCart(int userId)
        {
            try
            {
                await _cartRepository.ClearCart(userId);
                return Ok("Cart cleared");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while clearing the cart.");
            }
        }
    }
}