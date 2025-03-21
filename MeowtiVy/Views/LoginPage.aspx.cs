using System;
using System.Web.UI;
using MeowtiVy.Controllers;

namespace MeowtiVy.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private readonly UserController _userController;

        public LoginPage()
        {
            _userController = new UserController();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void loginAccount(object sender, EventArgs e)
        {
            string username = UsernameTB.Text;
            string password = PasswordTB.Text;

            bool isValidUser = _userController.ValidateUser(username, password);

            if (isValidUser)
            {
                Response.Redirect("HomePage.aspx");  
            }
            else
            {
                ErrorLabel.Text = "Invalid username or password.";
            }
        }
    }
}
        