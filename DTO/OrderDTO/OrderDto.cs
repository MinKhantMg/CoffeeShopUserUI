using System.ComponentModel.DataAnnotations;
using System.Data;
using CoffeeShopUser.Enums;

namespace CoffeeShopUser.DTO.OrderDTO
{
    public class OrderDto
    {
        public string Id { get; set; }  // Default to a new GUID
        public int TotalAmount { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string OrderStatus { get; set; } = "Pending"; // Optional: set default if needed

        [Required(ErrorMessage = "Order Type is required")]
        public string OrderType { get; set; } = Enum.GetName(typeof(OrderType), Enums.OrderType.DineIn);

        [Required(ErrorMessage = "Payment Type is required")]
        public string PaymentType { get; set; } = Enum.GetName(typeof(PaymentType), Enums.PaymentType.Cash);
    }

}
