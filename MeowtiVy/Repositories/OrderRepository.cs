using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Database;
using MeowtiVy.Models;

namespace MeowtiVy.Repositories
{
    public class OrderRepository
    {
        private readonly DatabaseContext _context;

        public OrderRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order GetOrderById(int orderId)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == orderId);
        }
    }
}