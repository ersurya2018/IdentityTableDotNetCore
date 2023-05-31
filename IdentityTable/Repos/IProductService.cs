using IdentityTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTable.Repos
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductListAsync();
        public Task<IEnumerable<Product>> GetProductByIdAsync(int Id);
        public Task<int> AddProductAsync(Product product);
        public Task<string> AddProductxml(Product product);
        public Task<int> UpdateProductAsync(Product product);
        public Task<int> DeleteProductAsync(int Id);
    }
}
