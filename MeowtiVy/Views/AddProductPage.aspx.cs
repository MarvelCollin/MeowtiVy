using System;
using System.Web.UI;
using MeowtiVy.Models;
using MeowtiVy.Controllers;
using MeowtiVy.Controller;

namespace MeowtiVy.Views
{
    public partial class AddProductPage : System.Web.UI.Page
    {
        private readonly ProductController _productController;

        public AddProductPage()
        {
            _productController = new ProductController();
        }

        protected void SaveProductBtn_Click(object sender, EventArgs e)
        {
            string name = NameTB.Text;
            decimal price = decimal.Parse(PriceTB.Text);
            int stockQuantity = int.Parse(StockQuantityTB.Text);

            _productController.AddProduct(name, price, stockQuantity);

            Response.Redirect("ProductPage.aspx");
        }
    }
}
