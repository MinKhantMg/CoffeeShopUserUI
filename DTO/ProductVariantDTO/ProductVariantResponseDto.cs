
namespace CoffeeShopUser.DTO.ProductVariantDTO
{
    public class ProductVariantResponseDto
    {
        public List<ProductVariantDto> ProductVariant { get; set; } = new();
        public int TotalItems { get; set; }
    }
}
