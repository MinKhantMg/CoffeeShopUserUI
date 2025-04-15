namespace CoffeeShopUser.DTO.CartItemDTO
{
    public class CartItemDto
    {
        public string Id { get; set; }
        public string CartId { get; set; }
        public string ProductVariantId { get; set; }
        public int Quantity { get; set; }
        public int ? Price { get; set; }
    }
}
