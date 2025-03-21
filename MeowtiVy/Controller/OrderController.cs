using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Database;
using MeowtiVy.Handlers;
using MeowtiVy.Repositories;

namespace MeowtiVy.Controller
{
    public class OrderController
    {
        private readonly OrderHandler _orderHandler;

        public OrderController()
        {
            var orderRepository = new OrderRepository(new DatabaseContext());
            var orderDetailRepository = new OrderDetailRepository(new DatabaseContext());
            var productRepository = new ProductRepository(new DatabaseContext());
            _orderHandler = new OrderHandler(orderRepository, orderDetailRepository, productRepository);
        }

        public void PlaceOrder(int userId, List<int> productIds, List<int> quantities)
        {
            _orderHandler.CreateOrder(userId, productIds, quantities);
        }
    }
}