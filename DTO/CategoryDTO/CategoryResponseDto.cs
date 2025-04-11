
namespace CoffeeShopUser.DTO.CategoryDTO
{
    public class CategoryResponseDto
    {
        public List<CategoryDto> Category { get; set; } = new();
        public int TotalItems { get; set; }
    }
}
