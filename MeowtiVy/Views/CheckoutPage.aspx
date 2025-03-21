<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="MeowtiVy.Views.CheckoutPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Your Orders</h2>
            <asp:GridView ID="OrderGridView" runat="server" AutoGenerateColumns="False" EmptyDataText="No orders found.">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Order ID" SortExpression="Id" />
                    <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" SortExpression="TotalAmount" />
                    <asp:BoundField DataField="OrderDate" HeaderText="Order Date" SortExpression="OrderDate" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                </Columns>
            </asp:GridView>

            <br />
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" />

            <br />
            <a href="HomePage.aspx">Back to Home</a> |
            <a href="ProductPage.aspx">Go to Products</a>
        </div>
    </form>
</body>
</html>
