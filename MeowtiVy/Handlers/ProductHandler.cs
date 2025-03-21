using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Models;
using MeowtiVy.Repositories;

namespace MeowtiVy.Handlers
{
    public class ProductHandler
    {
        private readonly ProductRepository _productRepository;

        public ProductHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public void AddProduct(string name, decimal price, int stockQuantity)
        {
            var product = new Product
            {
                Name = name,
                Price = price,
                StockQuantity = stockQuantity
            };

            _productRepository.AddProduct(product);
        }

        public void UpdateProduct(int id, string name, decimal price, int stockQuantity)
        {
            var product = new Product
            {
                Id = id,
                Name = name,
                Price = price,
                StockQuantity = stockQuantity
            };

            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }
    }
}