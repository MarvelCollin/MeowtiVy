using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Models;
using MeowtiVy.Repositories;

namespace MeowtiVy.Handlers
{
    public class OrderHandler
    {
        private readonly OrderRepository _orderRepository;
        private readonly OrderDetailRepository _orderDetailRepository;
        private readonly ProductRepository _productRepository;

        public OrderHandler(OrderRepository orderRepository, OrderDetailRepository orderDetailRepository, ProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public void CreateOrder(int userId, List<int> productIds, List<int> quantities)
        {
            decimal totalAmount = 0;
            var order = new Order
            {
                UserId = userId,
                OrderDate = System.DateTime.Now,
                Status = "Pending"
            };

            _orderRepository.AddOrder(order);

            for (int i = 0; i < productIds.Count; i++)
            {
                var product = _productRepository.GetProductById(productIds[i]);
                decimal price = product.Price;
                int quantity = quantities[i];
                decimal total = price * quantity;

                totalAmount += total;

                var orderDetail = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = productIds[i],
                    Quantity = quantity,
                    Price = price,
                    Total = total
                };

                _orderDetailRepository.AddOrderDetail(orderDetail);  
            }

            order.TotalAmount = totalAmount;
            _orderRepository.AddOrder(order);
        }
    }
}