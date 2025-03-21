using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Database;
using MeowtiVy.Models;

namespace MeowtiVy.Repositories
{
    public class OrderDetailRepository
    {
        private readonly DatabaseContext _context;

        public OrderDetailRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return _context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
        }
    }
}
