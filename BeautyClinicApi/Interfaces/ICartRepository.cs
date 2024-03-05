using BeautyClinicApi.Models;

namespace BeautyClinicApi.Interfaces
{
    public interface ICartRepository
    {
        Task AddItem(int userId, int productId, int quantity);
        Task RemoveItem(int cartItemId);
        Task<CartItem> UpdateQuantity(int cartItemId, int quantity);
        Task ClearCart(int userId);
        Task<IEnumerable<CartItem>> GetCartItems(int userId);
    }
}
