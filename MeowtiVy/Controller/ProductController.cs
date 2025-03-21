using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Database;
using MeowtiVy.Handlers;
using MeowtiVy.Models;
using MeowtiVy.Repositories;

namespace MeowtiVy.Controller
{
    public class ProductController
    {
        private readonly ProductHandler _productHandler;

        public ProductController()
        {
            var productRepository = new ProductRepository(new DatabaseContext());
            _productHandler = new ProductHandler(productRepository);
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _productHandler.GetAllProducts();
        }

        public void AddProduct(string name, decimal price, int stockQuantity)
        {
            _productHandler.AddProduct(name, price, stockQuantity);
        }

        public void UpdateProduct(int id, string name, decimal price, int stockQuantity)
        {
            _productHandler.UpdateProduct(id, name, price, stockQuantity);
        }

        public void DeleteProduct(int productId)
        {
            _productHandler.DeleteProduct(productId);
        }

        public Product GetProductById(int productId)
        {
            var product = _productHandler.GetAllProducts().FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                throw new Exception($"Product with ID {productId} does not exist.");
            }
            return product;
        }

    }
}