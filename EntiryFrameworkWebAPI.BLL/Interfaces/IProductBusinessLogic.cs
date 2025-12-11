using System;
using System.Collections.Generic;
using System.Text;
using EntiryFrameworkWebAPI.DAL.Models;

namespace EntiryFrameworkWebAPI.BLL.Interfaces
{
    public interface IProductBusinessLogic
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<bool> AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}
