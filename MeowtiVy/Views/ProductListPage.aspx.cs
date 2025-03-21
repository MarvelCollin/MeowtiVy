using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeowtiVy.Controller;

namespace MeowtiVy.Views
{
    public partial class ProductListPage : System.Web.UI.Page
    {
        private readonly ProductController _productController;

        public ProductListPage()
        {
            _productController = new ProductController();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var products = _productController.GetAllProducts();
                ProductGridView.DataSource = products;
                ProductGridView.DataBind();
            }
        }
    }
}