using System;
using System.Web.UI;

namespace MeowtiVy.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                WelcomeLabel.Text = "Welcome, " + Session["Username"].ToString() + "!";
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginPage.aspx");
        }
    }
}
