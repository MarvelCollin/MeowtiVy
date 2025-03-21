using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using MeowtiVy.Controller;
using MeowtiVy.Controllers;
using MeowtiVy.Database;
using MeowtiVy.Models;
using MeowtiVy.Repositories;

namespace MeowtiVy.Views
{
    public partial class CheckoutPage : System.Web.UI.Page
    {
        private readonly OrderController _orderController;
        private readonly UserController _userController;

        public CheckoutPage()
        {
            _orderController = new OrderController();
            _userController = new UserController();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    string username = Session["Username"].ToString();
                    int userId = GetUserIdByUsername(username);

                    var orders = GetOrdersByUserId(userId);

                    OrderGridView.DataSource = orders;
                    OrderGridView.DataBind();
                }
                else
                {
                    ErrorLabel.Text = "You must be logged in to view your orders.";
                }
            }
        }

        private int GetUserIdByUsername(string username)
        {
            var user = _userController.GetUserByUsername(username);
            return user != null ? user.Id : 0;
        }

        private IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            var orderRepository = new OrderRepository(new DatabaseContext());
            return orderRepository.GetOrdersByUserId(userId);
        }
    }
}
