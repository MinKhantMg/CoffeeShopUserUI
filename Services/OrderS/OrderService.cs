using CoffeeShopUser.DTO.OrderDTO;
using System.Net.Http.Json;

namespace CoffeeShopUser.Services.OrderS;

public class OrderService : IOrderService
{
    private readonly ApiClient _apiClient;

    public OrderService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<OrderSummaryDto> PreviewOrderSummary(CreateOrderDto dto)
    {
        try
        {
            var response = await _apiClient.PostAsync<OrderSummaryDto, CreateOrderDto>("/order/preview-summary", dto);

            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("Failed to fetch order summary.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error loading order summary: {ex.Message}");
        }
    }


    public async Task<OrderDto> PlaceOrder(CreateOrderDto dto)
    {
        try
        {
            var response = await _apiClient.PostAsync<OrderDto, CreateOrderDto>("/order/create", dto);

            if (response != null && !string.IsNullOrEmpty(response.Id))
            {
                return response;
            }
            else
            {
                throw new Exception("Failed to place order.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error placing order: {ex.Message}");
        }
    }

    public async Task<byte[]> DownloadReceipt(string orderId)
{
    var result = await _apiClient.GetByteArrayAsync($"/order/generate-receipt/{orderId}");
    
    if (result == null || result.Length == 0)
        throw new Exception("Failed to download receipt or receipt is empty.");

    return result;
}

}