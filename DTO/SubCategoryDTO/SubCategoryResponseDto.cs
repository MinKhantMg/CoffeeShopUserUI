
namespace CoffeeShopUser.DTO.SubCategoryDTO
{
    public class SubCategoryResponseDto
    {
        public List<SubCategoryDto> SubCategory { get; set; } = new();
        public int TotalItems { get; set; }
    }
}
