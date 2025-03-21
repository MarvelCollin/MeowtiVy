using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Models;
using MeowtiVy.Repositories;

namespace MeowtiVy.Handlers
{
    public class OrderDetailHandler
    {
        private readonly OrderDetailRepository _orderDetailRepository;

        public OrderDetailHandler(OrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public void AddOrderDetail(int orderId, int productId, int quantity, decimal price)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = quantity,
                Price = price,
                Total = price * quantity
            };

            _orderDetailRepository.AddOrderDetail(orderDetail);
        }
    }
}