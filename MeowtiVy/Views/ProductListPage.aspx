<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductListPage.aspx.cs" Inherits="MeowtiVy.Views.ProductListPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <h2>Product List</h2>
            <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="True" EmptyDataText="No products available." />
            <br /><br />
            <a href="CartPage.aspx">Go to Cart</a>
        </div>
    </form>
</body>
</html>
