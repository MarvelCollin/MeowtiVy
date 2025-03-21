<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MeowtiVy.Views.HomePage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Welcome to the Home Page!</h2>
            <asp:Label ID="WelcomeLabel" runat="server" Font-Size="Large" ForeColor="Green" />
            <br /><br />
            <asp:Button ID="LogoutBtn" runat="server" Text="Logout" OnClick="LogoutBtn_Click" />
            <br />
            <a href="ProductPage.aspx">Go to Products</a> | 
            <a href="CheckoutPage.aspx">Go to Checkout</a>
        </div>
    </form>
</body>
</html>
