using EntiryFrameworkWebAPI.BLL.Helpers;
using EntiryFrameworkWebAPI.BLL.Interfaces;
using EntiryFrameworkWebAPI.DAL.IRepository;
using EntiryFrameworkWebAPI.DAL.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EntiryFrameworkWebAPI.BLL.Service
{
    public class ProductBusinessLogicService : IProductBusinessLogic
    {
        private readonly IProductRepository _productRepository;

        public ProductBusinessLogicService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> AddProductAsync(Product product)
        {
            try
            {
                if (product == null)
                    throw new CustomeException(HttpStatusCode.BadRequest, "Product cannot be null");

                var result = await _productRepository.AddProductAsync(product);

                if (!result)
                    throw new CustomeException(HttpStatusCode.InternalServerError, "Failed to add product");

                return true;
            }
            catch (CustomeException)
            {
                Log.Error("Custom Exception occurred while adding product");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected error while adding product");
                throw new CustomeException(HttpStatusCode.InternalServerError, "An unexpected error occurred");
            }
        }


        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new CustomeException(HttpStatusCode.BadRequest, "Invalid product ID");

                var result = await _productRepository.DeleteProductAsync(id);

                if (!result)
                    throw new CustomeException(HttpStatusCode.InternalServerError, "Failed to delete product");

                return true;
            }
            catch (CustomeException)
            {
                Log.Error("Custom Exception occurred while deleting product");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected error while deleting product");
                throw new CustomeException(HttpStatusCode.InternalServerError, "An unexpected error occurred");
            }
        }


        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                var products = await _productRepository.GetAllProductsAsync();

                if (products == null || !products.Any())
                    throw new CustomeException(HttpStatusCode.NotFound, "No products found");

                return products;
            }
            catch (CustomeException)
            {
                Log.Error("Custom Exception occurred while fetching all products");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected error while fetching all products");
                throw new CustomeException(HttpStatusCode.InternalServerError, "An unexpected error occurred");
            }
        }


        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new CustomeException(HttpStatusCode.BadRequest, "Invalid product ID");

                var product = await _productRepository.GetProductByIdAsync(id);

                if (product == null)
                    throw new CustomeException(HttpStatusCode.NotFound, "Product not found");

                return product;
            }
            catch (CustomeException)
            {
                Log.Error($"Custom Exception occurred while fetching product with ID {id}");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Unexpected error while fetching product with ID {id}");
                throw new CustomeException(HttpStatusCode.InternalServerError, "An unexpected error occurred");
            }
        }


        public async Task<bool> UpdateProductAsync(Product product)
        {
            try
            {
                if (product == null)
                    throw new CustomeException(HttpStatusCode.BadRequest, "Product cannot be null");

                var result = await _productRepository.UpdateProductAsync(product);

                if (!result)
                    throw new CustomeException(HttpStatusCode.InternalServerError, "Failed to update product");

                return true;
            }
            catch (CustomeException)
            {
                Log.Error("Custom Exception occurred while updating product");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected error while updating product");
                throw new CustomeException(HttpStatusCode.InternalServerError, "An unexpected error occurred");
            }
        }

    }
}
