using System;
using System.Linq;
using MeowtiVy.Database;
using MeowtiVy.Models;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;

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
            var orderExists = _context.Orders.Any(o => o.Id == orderDetail.OrderId);
            if (!orderExists)
            {
                throw new Exception("Order does not exist.");
            }

            var productExists = _context.Products.Any(p => p.Id == orderDetail.ProductId);
            if (!productExists)
            {
                throw new Exception("Product does not exist.");
            }

            if (orderDetail.OrderId == 0 || orderDetail.ProductId == 0 || orderDetail.Quantity <= 0 || orderDetail.Price <= 0)
            {
                throw new Exception("Invalid OrderDetail values.");
            }

            try
            {
                _context.OrderDetails.Add(orderDetail);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                string innerExceptionMessage = ex.InnerException?.Message ?? "No inner exception details.";
                string innerStackTrace = ex.InnerException?.StackTrace ?? "No inner exception stack trace.";
                string exceptionMessage = ex.Message;
                string stackTrace = ex.StackTrace;

                Console.WriteLine($"Exception: {exceptionMessage}");
                Console.WriteLine($"Inner Exception: {innerExceptionMessage}");
                Console.WriteLine($"Inner Stack Trace: {innerStackTrace}");
                Console.WriteLine($"Stack Trace: {stackTrace}");

                throw new Exception($"An error occurred while saving the order details: {exceptionMessage}", ex);
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return _context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
        }
    }
}
