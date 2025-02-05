using zealightlabs_assessment.Dtos.Requests;


namespace zealightlabs_assessment.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductResponseDto> CreateAsync(ProductRequestDto productDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ProductResponseDto>> GetAllAsync();
        Task<ProductResponseDto?> GetByIdAsync(int id);
        Task<List<string>> GetCategoriesAsync();
        Task<List<CategoryDto>> GetCategoriesDTOAsync();
        Task<PaginatedList<ProductResponseDto>> GetFilteredPaginatedAsync(int pageNumber, int pageSize, string category, int maxPrice);
        Task<PaginatedList<ProductResponseDto>> GetFilteredPaginatedAsync(int pageNumber, int pageSize, string category, int maxPrice, string searchQuery);
        Task<PaginatedList<ProductResponseDto>> GetPaginatedAsync(int pageNumber, int pageSize);
        Task<List<string>> GetSearchSuggestionsAsync(string searchQuery);
        Task<ProductResponseDto> UpdateAsync(int id, ProductRequestDto productDto);
    }
}