using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();    
        Task<IReadOnlyList<Brand>> GetProductBrandsAsync();
        Task<IReadOnlyList<Category>> GetProductCategoriesAsync();
    }
}