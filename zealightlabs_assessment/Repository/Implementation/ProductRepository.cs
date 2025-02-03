using Microsoft.EntityFrameworkCore;
using zealightlabs_assessment.Data;
using zealightlabs_assessment.Dtos.Requests;
using zealightlabs_assessment.Entities;

using zealightlabs_assessment.Repository.Interfaces;

namespace zealightlabs_assessment.Repository.Implementation
{
    public class ProductRepository(AppDbContext dbContext) : IProductRepository
    {
        public async Task<ProductResponseDto> CreateAsync(ProductRequestDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId // Set CategoryId here
            };

            dbContext.Add(product);
            await dbContext.SaveChangesAsync();

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId, // Include CategoryId in response
                CategoryName = product.Category?.Name // Optionally, include Category name in response
            };
        }

        public async Task<ProductResponseDto> UpdateAsync(int id, ProductRequestDto productDto)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product == null) throw new Exception("Product not found");

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.CategoryId = productDto.CategoryId; // Update CategoryId

            await dbContext.SaveChangesAsync();

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId, // Include updated CategoryId in response
                CategoryName = product.Category?.Name // Include updated Category name in response
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product == null) return false;

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            var product = await dbContext.Products
                                          .Include(p => p.Category) // Ensure Category is included in the query
                                          .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return null;

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name // Include Category name in response
            };
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            return await dbContext.Products
                        .Include(p => p.Category) // Ensure Category is included in the query
                        .Select(p => new ProductResponseDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Description = p.Description,
                            Price = p.Price,
                            CategoryId = p.CategoryId,
                            CategoryName = p.Category.Name // Include Category name in response
                        })
                        .ToListAsync();
        }

        public async Task<PaginatedList<ProductResponseDto>> GetPaginatedAsync(int pageNumber, int pageSize)
        {
            var query = dbContext.Products
                                 .Include(p => p.Category) // Ensure Category is included in the query
                                 .Select(p => new ProductResponseDto
                                 {
                                     Id = p.Id,
                                     Name = p.Name,
                                     Description = p.Description,
                                     Price = p.Price,
                                     CategoryId = p.CategoryId,
                                     CategoryName = p.Category.Name // Include Category name in response
                                 });

            return await PaginatedList<ProductResponseDto>.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<PaginatedList<ProductResponseDto>> GetFilteredPaginatedAsync(int pageNumber, int pageSize, string category, int maxPrice)
        {
            var query = dbContext.Products
                .Include(p => p.Category)
                .Where(p => (string.IsNullOrEmpty(category) || p.Category.Name == category) && p.Price <= maxPrice)
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryName = p.Category.Name
                });

            return await PaginatedList<ProductResponseDto>.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<List<string>> GetCategoriesAsync()
        {
            return await dbContext.Categories.Select(c=>c.Name
            ).ToListAsync();
        }
        public async Task<List<CategoryDto>> GetCategoriesDTOAsync()
        {
            return await dbContext.Categories.Select(c =>new CategoryDto
            {
                Name = c.Name,
                Id = c.Id,

            }
            ).ToListAsync();
        }

    }
}
