using CoffeeShopUser.DTO.OrderDTO;

namespace CoffeeShopUser.Services.OrderS
{
    public interface IOrderService
    {
        Task<OrderDto> PlaceOrder(CreateOrderDto orderDto);

        Task<OrderSummaryDto> PreviewOrderSummary(CreateOrderDto dto);

        Task<byte[]> DownloadReceipt(string orderId);
    }
}
