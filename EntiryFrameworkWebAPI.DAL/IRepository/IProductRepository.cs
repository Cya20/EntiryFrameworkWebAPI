using EntiryFrameworkWebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntiryFrameworkWebAPI.DAL.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<bool> AddProductAsync (Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);

    }
}
