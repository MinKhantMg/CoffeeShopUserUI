using CoffeeShopUser.DTO.CategoryDTO;
using CoffeeShopUser.DTO.ProductDTO;
using CoffeeShopUser.DTO.ProductVariantDTO;
using CoffeeShopUser.DTO.SubCategoryDTO;

namespace CoffeeShopUser.Services.CategoryS
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategory();

        Task<List<SubCategoryDto>> GetSubcategoriesByCategoryIdAsync(string categoryId);

        Task<List<ProductDto>> GetProductsBySubCategoryIdAsync(string subcategoryId);

        Task<List<ProductVariantDto>> GetProductVariantsByProductIdAsync(string productId);

        Task RefreshAllCacheAsync();
    }
}
