using System.Collections.Generic;
using System.Threading.Tasks;
using TtcApi.Models;

namespace TtcApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(string productName);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(string productName);
    }
}
