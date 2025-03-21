using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeowtiVy.Controllers;
using MeowtiVy.Models;
using MeowtiVy.Repositories;
using System.Web.UI;
using MeowtiVy.Controller;
using MeowtiVy.Database;
using System.Web.UI.WebControls;

namespace MeowtiVy.Views
{
    public partial class CheckoutPage : System.Web.UI.Page
    {
        private readonly OrderController _orderController;
        private readonly ProductRepository _productRepository;
        private readonly OrderDetailRepository _orderDetailRepository;

        public CheckoutPage()
        {
            _orderController = new OrderController();
            _productRepository = new ProductRepository(new DatabaseContext());
            _orderDetailRepository = new OrderDetailRepository(new DatabaseContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    string username = Session["Username"].ToString();
                    int userId = GetUserIdByUsername(username); 

                    var orderDetails = GetOrderDetails(userId);

                    OrderGridView.DataSource = orderDetails;
                    OrderGridView.DataBind();
                }
                else
                {
                    ErrorLabel.Text = "You must be logged in to place an order.";
                }
            }
        }

        protected void PlaceOrderBtn_Click(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                string username = Session["Username"].ToString();
                int userId = GetUserIdByUsername(username);

                List<int> productIds = new List<int>();
                List<int> quantities = new List<int>();

                foreach (GridViewRow row in OrderGridView.Rows)
                {
                    int productId = Convert.ToInt32(OrderGridView.DataKeys[row.RowIndex].Value);
                    int quantity = Convert.ToInt32(((TextBox)row.FindControl("QuantityTextBox")).Text);
                    productIds.Add(productId);
                    quantities.Add(quantity);
                }

                try
                {
                    _orderController.PlaceOrder(userId, productIds, quantities);
                    Response.Redirect("OrderConfirmationPage.aspx"); 
                }
                catch (Exception ex)
                {
                    ErrorLabel.Text = "An error occurred while placing your order: " + ex.Message;
                }
            }
        }

        private int GetUserIdByUsername(string username)
        {
            var user = new UserRepository(new DatabaseContext()).GetUserByUsername(username);
            return user != null ? user.Id : 0;
        }

        private List<OrderDetail> GetOrderDetails(int userId)
        {
            var orderDetails = new List<OrderDetail>();

            var orders = new OrderRepository(new DatabaseContext()).GetOrderById(userId);

            if (orders != null)
            {
                orderDetails = _orderDetailRepository.GetOrderDetailsByOrderId(orders.Id).ToList();

                foreach (var orderDetail in orderDetails)
                {
                    var product = _productRepository.GetProductById(orderDetail.ProductId);
                    orderDetail.ProductName = product?.Name;
                }
            }

            return orderDetails;
        }



    }
}
