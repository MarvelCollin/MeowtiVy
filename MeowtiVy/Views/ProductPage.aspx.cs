using System;
using System.Linq;
using System.Web.UI;
using MeowtiVy.Controller;
using System.Web.UI.WebControls;
using MeowtiVy.Controllers;

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
    }
}
