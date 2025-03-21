using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeowtiVy.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        public string ProductName { get; set; }
    }
}