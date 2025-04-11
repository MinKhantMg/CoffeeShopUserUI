
namespace CoffeeShopUser.DTO.ProductDTO
{
    public class ProduxtResponseDto
    {
        public List<ProductDto> Product { get; set; } = new();
        public int TotalItems { get; set; }
    }
}
