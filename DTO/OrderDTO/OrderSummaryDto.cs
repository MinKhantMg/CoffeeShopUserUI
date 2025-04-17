namespace CoffeeShopUser.DTO.OrderDTO
{
    public class OrderSummaryDto
    {
        public string Id { get; set; }
        public string OrderType { get; set; }
        public string PaymentType { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }

}
