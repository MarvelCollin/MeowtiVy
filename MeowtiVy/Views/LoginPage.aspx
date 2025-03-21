<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MeowtiVy.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head> 
<body>
     <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <label for="UsernameTB">Username: </label>
            <asp:TextBox ID="UsernameTB" runat="server" Required="True"></asp:TextBox>
            <br /><br />
            <label for="PasswordTB">Password: </label>
            <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password" Required="True"></asp:TextBox>
            <br /><br />
            <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="loginAccount" />
            <br /><br />
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" />
            <br /><br />
            <a href="RegisterPage.aspx">Don't have an account? Register here</a>
        </div>
    </form>
</body>
</html>
