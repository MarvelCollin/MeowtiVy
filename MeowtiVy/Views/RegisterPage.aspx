<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="MeowtiVy.Views.RegisterPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Register</h2>
            
            <label for="UsernameTB">Username: </label>
            <asp:TextBox ID="UsernameTB" runat="server" Required="True"></asp:TextBox>
            <br /><br />
            
            <label for="PasswordTB">Password: </label>
            <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password" Required="True"></asp:TextBox>
            <br /><br />
            
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
            
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" />
            
            <br /><br />
            <a href="LoginPage.aspx">Already have an account? Login here</a>
        </div>
    </form>
</body>
</html>
