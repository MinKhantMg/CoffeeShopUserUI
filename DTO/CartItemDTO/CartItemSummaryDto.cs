namespace CoffeeShopUser.DTO.CartItemDTO
{
    public class CartItemSummaryDto
    {
        public List<CartItemDisplayDto> CartItems { get; set; }
        public int TotalPrice { get; set; }
    }
}
