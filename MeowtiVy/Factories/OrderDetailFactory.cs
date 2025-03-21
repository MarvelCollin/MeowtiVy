using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Models;

namespace MeowtiVy.Factories
{
    public class OrderDetailFactory
    {
        public static OrderDetail CreateOrderDetail(int orderId, int productId, int quantity, decimal price)
        {
            var total = price * quantity;
            return new OrderDetail
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = quantity,
                Price = price,
                Total = total
            };
        }
    }
}