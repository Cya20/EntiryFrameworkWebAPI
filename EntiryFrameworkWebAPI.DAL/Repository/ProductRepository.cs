using EntiryFrameworkWebAPI.DAL.Data;
using EntiryFrameworkWebAPI.DAL.IRepository;
using EntiryFrameworkWebAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntiryFrameworkWebAPI.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddProductAsync(Product product)
        {
            try
            {
                var  newProduct = await _context.Products.AddAsync(product);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var entity = await _context.Products.FindAsync(id);

                if(entity != null)
                {
                    _context.Products.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new ArgumentException("Product not found");
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                var products = await _context.Products.ToListAsync();

                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);

                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            try
            {
                var entity = await _context.Products.FindAsync(product.Id);


                if(entity != null)
                {
                    entity.Name = product.Name;
                    entity.Price = product.Price;
                    _context.Products.Update(entity);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new ArgumentException("Product not found");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
