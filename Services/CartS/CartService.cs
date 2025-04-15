using Blazored.LocalStorage;
using CoffeeShopUser.DTO.CartDTO;
using CoffeeShopUser.DTO.CartItemDTO;

namespace CoffeeShopUser.Services.CartS
{
    public class CartService : ICartService
    {
        private readonly ApiClient _apiClient;
        private readonly ILocalStorageService _localStorage;
        private const string CartIdKey = "cartId";

        public CartService(ApiClient apiClient, ILocalStorageService localStorage)
        {
            _apiClient = apiClient;
            _localStorage = localStorage;
        }

        public async Task<string> GetOrCreateCartIdAsync()
        {
            var cartId = await _localStorage.GetItemAsync<string>(CartIdKey);

            if (!string.IsNullOrEmpty(cartId))
            {
                return cartId;
            }

            var newCartDto = new CartDto();
            var createdCart = await _apiClient.PostAsync<CartDto, CartDto>("/cart", newCartDto);

            if (createdCart != null && !string.IsNullOrEmpty(createdCart.Id))
            {
                await _localStorage.SetItemAsync(CartIdKey, createdCart.Id);
                return createdCart.Id;
            }

            throw new Exception("Failed to create a new cart.");
        }

        public async Task AddToCartAsync(CartItemDto cartItemDto)
        {
            await _apiClient.PostAsync<object, CartItemDto>("/cartitem", cartItemDto);
        }
    }
}
