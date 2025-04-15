using CoffeeShopUser.DTO.CartItemDTO;

namespace CoffeeShopUser.Services.CartS
{
    public interface ICartService
    {
        Task<string> GetOrCreateCartIdAsync();
        Task AddToCartAsync(CartItemDto cartItemDto);
    }
}
