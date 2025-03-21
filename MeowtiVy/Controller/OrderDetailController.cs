using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Database;
using MeowtiVy.Handlers;
using MeowtiVy.Repositories;

namespace MeowtiVy.Controller
{
    public class OrderDetailController
    {
        private readonly OrderDetailHandler _orderDetailHandler;

        public OrderDetailController()
        {
            var orderDetailRepository = new OrderDetailRepository(new DatabaseContext());
            _orderDetailHandler = new OrderDetailHandler(orderDetailRepository);
        }

        public void AddOrderDetail(int orderId, int productId, int quantity, decimal price)
        {
            _orderDetailHandler.AddOrderDetail(orderId, productId, quantity, price);
        }
    }
}