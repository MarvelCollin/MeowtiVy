<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProductPage.aspx.cs" Inherits="MeowtiVy.Views.AddProductPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Product</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Add New Product</h2>
            <label for="NameTB">Product Name: </label>
            <asp:TextBox ID="NameTB" runat="server" Required="True"></asp:TextBox>
            <br /><br />

            <label for="PriceTB">Price: </label>
            <asp:TextBox ID="PriceTB" runat="server" Required="True"></asp:TextBox>
            <br /><br />

            <label for="StockQuantityTB">Stock Quantity: </label>
            <asp:TextBox ID="StockQuantityTB" runat="server" Required="True"></asp:TextBox>
            <br /><br />

            <asp:Button ID="SaveProductBtn" runat="server" Text="Save Product" OnClick="SaveProductBtn_Click" />
        </div>
    </form>
</body>
</html>
