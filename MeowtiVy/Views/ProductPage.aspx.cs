using System;
using System.Collections.Generic;
using System.Web.UI;
using MeowtiVy.Controller;
using System.Web.UI.WebControls;
using MeowtiVy.Controllers;
using MeowtiVy.Database;
using MeowtiVy.Models;
using MeowtiVy.Repositories;
using System.Linq;

namespace MeowtiVy.Views
{
    public partial class ProductPage : System.Web.UI.Page
    {
        private readonly ProductController _productController;
        private readonly OrderController _orderController;

        public ProductPage()
        {
            _productController = new ProductController();
            _orderController = new OrderController();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                AddProductBtn.Visible = false;
            }
            else
            {
                AddProductBtn.Visible = true;
            }

            if (!IsPostBack)
            {
                var products = _productController.GetAllProducts().ToList();
                ProductGridView.DataSource = products;
                ProductGridView.DataBind();
            }
        }

        protected void AddProductBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProductPage.aspx");
        }

        protected void ProductGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int productId = Convert.ToInt32(ProductGridView.DataKeys[e.NewEditIndex].Value);
            Response.Redirect("EditProductPage.aspx?ProductId=" + productId);
        }

        protected void ProductGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(ProductGridView.DataKeys[e.RowIndex].Value);
            _productController.DeleteProduct(productId);
            Response.Redirect("ProductPage.aspx");
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32((sender as Button).CommandArgument);
            var quantityTextBox = (TextBox)((Button)sender).Parent.FindControl("QuantityTextBox");
            int quantity = Convert.ToInt32(quantityTextBox.Text);

            if (Session["Username"] != null)
            {
                string username = Session["Username"].ToString();
                int userId = GetUserIdByUsername(username);

                _orderController.PlaceOrder(userId, new List<int> { productId }, new List<int> { quantity });

                SuccessMessageLabel.Text = "Your order has been placed successfully!";
                SuccessMessageLabel.Visible = true;
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }

        private int GetUserIdByUsername(string username)
        {
            var user = new UserRepository(new DatabaseContext()).GetUserByUsername(username);
            return user != null ? user.Id : 0;
        }
    }
}
