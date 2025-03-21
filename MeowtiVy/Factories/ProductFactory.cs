using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Models;

namespace MeowtiVy.Factories
{
    public class ProductFactory
    {
        public static Product CreateProduct(string name, decimal price, int stockQuantity)
        {
            return new Product
            {
                Name = name,
                Price = price,
                StockQuantity = stockQuantity
            };
        }
    }
}