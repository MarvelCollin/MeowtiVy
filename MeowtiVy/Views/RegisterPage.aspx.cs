using System;
using System.Diagnostics;
using System.Web.UI;
using MeowtiVy.Controllers;

namespace MeowtiVy.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        private readonly UserController _userController;

        public RegisterPage()
        {
            _userController = new UserController();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTB.Text;
            string password = PasswordTB.Text;

            try
            {
                Debug.WriteLine(username, password);
                _userController.RegisterUser(username, password);
                Response.Redirect("LoginPage.aspx");
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = "An error occurred: " + ex.Message;

                string errorDetails = "Exception Message: " + ex.Message + "<br />";
                if (ex.InnerException != null)
                {
                    errorDetails += "Inner Exception: " + ex.InnerException.Message + "<br />";
                    errorDetails += "Inner StackTrace: " + ex.InnerException.StackTrace + "<br />";
                }
                errorDetails += "StackTrace: " + ex.StackTrace;

                ErrorLabel.Text += "<br />" + errorDetails;
            }
        }
    }
}
