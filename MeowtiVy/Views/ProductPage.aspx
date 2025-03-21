<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="MeowtiVy.Views.ProductPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Product List</h2>

            <asp:Button ID="AddProductBtn" runat="server" Text="Add Product" OnClick="AddProductBtn_Click" Visible="false" />
            <br /><br />

            <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="False" EmptyDataText="No products available."
                OnRowEditing="ProductGridView_RowEditing" OnRowDeleting="ProductGridView_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Product Name" SortExpression="Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="EditButton" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' Visible='<%# Session["Role"] != null && Session["Role"].ToString() == "Admin" %>' />
                            <asp:LinkButton ID="DeleteButton" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' Visible='<%# Session["Role"] != null && Session["Role"].ToString() == "Admin" %>' />

                            <asp:TextBox ID="QuantityTextBox" runat="server" Text="1" Width="50px" Visible='<%# Session["Role"] == null || Session["Role"].ToString() != "Admin" %>' />
                            <asp:Button ID="CheckoutButton" runat="server" Text="Checkout" CommandName="Checkout" CommandArgument='<%# Eval("Id") %>' Visible='<%# Session["Role"] == null || Session["Role"].ToString() != "Admin" %>' OnClick="CheckoutButton_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <br /><br />

            <asp:Label ID="SuccessMessageLabel" runat="server" ForeColor="Green" Visible="false" />
            <br />

            <a href="HomePage.aspx">Back to Home</a> |
            <a href="CheckoutPage.aspx">Go to Checkout</a>
        </div>
    </form>
</body>
</html>
