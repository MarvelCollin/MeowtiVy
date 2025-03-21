using System;
using System.Linq;
using System.Web.UI;
using MeowtiVy.Controllers;
using System.Web.UI.WebControls;
using MeowtiVy.Controller;
using MeowtiVy.Models;

namespace MeowtiVy.Views
{
    public partial class ProductPage : System.Web.UI.Page
    {
        private readonly ProductController _productController;

        public ProductPage()
        {
            _productController = new ProductController();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                AddProductBtn.Visible = false;
                ProductForm.Visible = false;
            }
            else
            {
                AddProductBtn.Visible = true;
                ProductForm.Visible = false;
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
            ProductForm.Visible = true; 
        }

        protected void ProductGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int productId = Convert.ToInt32(ProductGridView.DataKeys[e.NewEditIndex].Value);
            Product product = _productController.GetAllProducts().FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                ProductNameTextBox.Text = product.Name;
                ProductPriceTextBox.Text = product.Price.ToString();
                ProductStockQuantityTextBox.Text = product.StockQuantity.ToString();
                ProductForm.Visible = true;
                ViewState["ProductId"] = productId;
            }
        }

        protected void ProductGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(ProductGridView.DataKeys[e.RowIndex].Value);
            _productController.DeleteProduct(productId);
            Response.Redirect("ProductPage.aspx");
        }

        protected void SaveProductBtn_Click(object sender, EventArgs e)
        {
            string productName = ProductNameTextBox.Text;
            decimal productPrice = Convert.ToDecimal(ProductPriceTextBox.Text);
            int productStockQuantity = Convert.ToInt32(ProductStockQuantityTextBox.Text);

            if (!string.IsNullOrEmpty(productName) && productPrice > 0 && productStockQuantity >= 0)
            {
                _productController.AddProduct(productName, productPrice, productStockQuantity);
                ProductForm.Visible = false;
                Response.Redirect("ProductPage.aspx");
            }
            else
            {
                ErrorLabel.Text = "Please ensure all fields are filled correctly.";
            }
        }
    }
}
