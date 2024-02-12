using BeautyClinicApi.Data;
using BeautyClinicApi.Interfaces;
using BeautyClinicApi.Models;
using Microsoft.EntityFrameworkCore;

public class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _context;

    public CartRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddItem(int userId, int productId, int quantity)
    {
        // Attempt to retrieve the user's existing cart
        var cart = await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        // If no cart exists, create a new one
        if (cart == null)
        {
            cart = new Cart { UserId = userId, Items = new List<CartItem>() };
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync(); // Save to get the new CartId
        }

        // Check if the item is already in the cart
        var cartItem = cart.Items
            .FirstOrDefault(ci => ci.ProductId == productId);

        if (cartItem != null)
        {
            // If item exists, increase the quantity
            cartItem.Quantity += quantity;
        }
        else
        {
            // If item does not exist, add a new cart item
            var product = await _context.Products.FindAsync(productId);
            cartItem = new CartItem
            {
                ProductId = productId,
                Quantity = quantity,
                Price = product.Price // Assuming this is the current price of the product
            };
            cart.Items.Add(cartItem);
        }

        await _context.SaveChangesAsync();
    }

    public async Task RemoveItem(int cartItemId)
    {
        var cartItem = await _context.CartItems.FindAsync(cartItemId);
        if (cartItem != null)
        {
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateQuantity(int cartItemId, int quantity)
    {
        var cartItem = await _context.CartItems.FindAsync(cartItemId);
        if (cartItem != null)
        {
            cartItem.Quantity = quantity;
            await _context.SaveChangesAsync();
        }
    }

    public async Task ClearCart(int userId)
    {
        var cartItems = _context.CartItems.Where(ci => ci.Cart.UserId == userId);
        _context.CartItems.RemoveRange(cartItems);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CartItem>> GetCartItems(int userId)
    {
        return await _context.CartItems
            .Where(ci => ci.Cart.UserId == userId)
            .ToListAsync();
    }
}