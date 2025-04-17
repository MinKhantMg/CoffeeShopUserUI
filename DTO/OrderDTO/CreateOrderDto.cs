namespace CoffeeShopUser.DTO.OrderDTO
{
    public class CreateOrderDto
    {
        public string CartId { get; set; }
        public string OrderType { get; set; } // e.g., DineIn, TakeAway
        public string PaymentType { get; set; } // e.g., Cash, Card
    }

}
