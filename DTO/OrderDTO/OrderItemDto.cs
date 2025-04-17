namespace CoffeeShopUser.DTO.OrderDTO
{
    public class OrderItemDto
    {
        public string ProductVariantName { get; set; } 
        public int Quantity { get; set; }              
        public decimal SubTotal { get; set; }          
    }

}
