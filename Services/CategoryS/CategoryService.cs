using CoffeeShopUser.DTO.CategoryDTO;
using CoffeeShopUser.DTO.ProductDTO;
using CoffeeShopUser.DTO.ProductVariantDTO;
using CoffeeShopUser.DTO.SubCategoryDTO;
using CoffeeShopUser.Services.CategoryS;
using CoffeeShopUser.Services;
using Microsoft.Extensions.Caching.Memory;

public class CategoryService : ICategoryService
{
    private readonly ApiClient _apiClient;
    private readonly IMemoryCache _memoryCache;

    public CategoryService(ApiClient apiClient, IMemoryCache memoryCache)
    {
        _apiClient = apiClient;
        _memoryCache = memoryCache;
    }

    public async Task<List<CategoryDto>> GetAllCategory()
    {
        if (!_memoryCache.TryGetValue("categories", out List<CategoryDto> cachedCategories))
        {
            Console.WriteLine("api call");
            var response = await _apiClient.GetFromJsonAsync<CategoryResponseDto>("/category/all");
            cachedCategories = response?.Category ?? new List<CategoryDto>();
            _memoryCache.Set("categories", cachedCategories); 
        }
        Console.WriteLine("Cashing call");
        return cachedCategories;
    }

    public async Task<List<SubCategoryDto>> GetSubcategoriesByCategoryIdAsync(string categoryId)
    {
        if (!_memoryCache.TryGetValue($"subcategories_{categoryId}", out List<SubCategoryDto> cachedSubcategories))
        {
            var response = await _apiClient.GetFromJsonAsync<List<SubCategoryDto>>($"/subcategory/all/{categoryId}");
            cachedSubcategories = response ?? new List<SubCategoryDto>();
            _memoryCache.Set($"subcategories_{categoryId}", cachedSubcategories); 
        }
        return cachedSubcategories;
    }

    public async Task<List<ProductDto>> GetProductsBySubCategoryIdAsync(string subcategoryId)
    {
        if (!_memoryCache.TryGetValue($"products_{subcategoryId}", out List<ProductDto> cachedProducts))
        {
            var response = await _apiClient.GetFromJsonAsync<List<ProductDto>>($"/product/all/{subcategoryId}");
            cachedProducts = response ?? new List<ProductDto>();
            _memoryCache.Set($"products_{subcategoryId}", cachedProducts);
        }
        return cachedProducts;
    }

    public async Task<List<ProductVariantDto>> GetProductVariantsByProductIdAsync(string productId)
    {
        if (!_memoryCache.TryGetValue($"productVariants_{productId}", out List<ProductVariantDto> cachedProductVariants))
        {
            var response = await _apiClient.GetFromJsonAsync<List<ProductVariantDto>>($"/productvariant/all/{productId}");
            cachedProductVariants = response ?? new List<ProductVariantDto>();
            _memoryCache.Set($"productVariants_{productId}", cachedProductVariants); 
        }
        return cachedProductVariants;
    }

    public async Task<ProductVariantDto> GetProductVariantsByIdAsync(string productId)
    {
        if (!_memoryCache.TryGetValue($"productVariants_{productId}", out ProductVariantDto cachedProductVariants))
        {
            var response = await _apiClient.GetFromJsonAsync<ProductVariantDto>($"/productvariant/{productId}");
            cachedProductVariants = response ?? new ProductVariantDto();
            _memoryCache.Set($"productVariants_{productId}", cachedProductVariants);
        }
        return cachedProductVariants;
    }

    public async Task RefreshAllCacheAsync()
    {
        _memoryCache.Remove("categories");

        var categories = await _apiClient.GetFromJsonAsync<CategoryResponseDto>("/category/all");
        var freshCategories = categories?.Category ?? new List<CategoryDto>();
        _memoryCache.Set("categories", freshCategories);

        foreach (var category in freshCategories)
        {
            string subKey = $"subcategories_{category.Id}";
            _memoryCache.Remove(subKey);

            var subcategories = await _apiClient.GetFromJsonAsync<List<SubCategoryDto>>($"/subcategory/all/{category.Id}");
            var freshSubs = subcategories ?? new List<SubCategoryDto>();
            _memoryCache.Set(subKey, freshSubs);

            foreach (var sub in freshSubs)
            {
                string productKey = $"products_{sub.Id}";
                _memoryCache.Remove(productKey);

                var products = await _apiClient.GetFromJsonAsync<List<ProductDto>>($"/product/all/{sub.Id}");
                var freshProducts = products ?? new List<ProductDto>();
                _memoryCache.Set(productKey, freshProducts);

                foreach (var product in freshProducts)
                {
                    string variantKey = $"variants_{product.Id}";
                    _memoryCache.Remove(variantKey);

                    var variants = await _apiClient.GetFromJsonAsync<List<ProductVariantDto>>($"/productvariant/all/{product.Id}");
                    _memoryCache.Set(variantKey, variants ?? new List<ProductVariantDto>());
                }
            }
        }
    }

}
