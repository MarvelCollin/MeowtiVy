<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="MeowtiVy.Views.CheckoutPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Checkout</h2>
            <br />

            <asp:GridView ID="OrderGridView" runat="server" AutoGenerateColumns="False" EmptyDataText="No products in order." 
                OnRowEditing="OrderGridView_RowEditing" OnRowDeleting="OrderGridView_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Eval("Quantity") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>


            <br />

            <asp:Button ID="PlaceOrderBtn" runat="server" Text="Place Order" OnClick="PlaceOrderBtn_Click" />
            <br />
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" />
            <br /><br />
            <a href="HomePage.aspx">Back to Home</a> |
            <a href="ProductPage.aspx">Go to Products</a>
        </div>
    </form>
</body>
</html>
