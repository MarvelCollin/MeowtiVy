using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Models;

namespace MeowtiVy.Factories
{
    public class OrderFactory
    {
        public static Order CreateOrder(int userId, decimal totalAmount)
        {
            return new Order
            {
                UserId = userId,
                OrderDate = System.DateTime.Now,
                TotalAmount = totalAmount,
                Status = "Pending"
            };
        }
    }
}