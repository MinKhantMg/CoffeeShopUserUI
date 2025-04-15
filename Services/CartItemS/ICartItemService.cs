
using CoffeeShopUser.DTO.CartItemDTO;

namespace CoffeeShopUser.Services.CartItemS
{
    public interface ICartItemService
    {
        Task AddCartItemAsync(CartItemDto cartItemDto);
        Task<CartItemSummaryDto> GetCartItemsByCartIdAsync(string cartId);
        Task UpdateCartItemQuantityAsync(string cartItemId, int newQuantity);
        Task DeleteCartItemAsync(string cartItemId);
    }
}
