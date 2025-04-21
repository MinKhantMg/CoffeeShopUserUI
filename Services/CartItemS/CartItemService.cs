 using CoffeeShopUser.DTO.CartItemDTO;

namespace CoffeeShopUser.Services.CartItemS
{
    public class CartItemService : ICartItemService
    {
        private readonly ApiClient _apiClient;

        public CartItemService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task AddCartItemAsync(CartItemDto cartItemDto)
        {
            await _apiClient.PostAsync<object, CartItemDto>("/cartitem", cartItemDto);
        }

        public async Task<CartItemSummaryDto> GetCartItemsByCartIdAsync(string cartId)
        {
            return await _apiClient.GetFromJsonAsync<CartItemSummaryDto>($"/cartitem/{cartId}")
                   ?? new CartItemSummaryDto();
        }

        public async Task UpdateCartItemQuantityAsync(string cartItemId, int newQuantity)
        {
            var updateDto = new
            {
                Id = cartItemId,
                Quantity = newQuantity
            };

            await _apiClient.PutAsync<object, object>($"/cartitem/adjust", updateDto);
        }

        public async Task DeleteCartItemAsync(string cartItemId)
        {
            await _apiClient.DeleteAsync($"/cartitem/{cartItemId}");
        }
    }
}
