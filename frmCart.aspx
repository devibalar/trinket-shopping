<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmCart.aspx.cs" Inherits="Cart1" MasterPageFile="~/MasterTemplate.master" %>
<asp:Content ID="carthead" ContentPlaceHolderID="head" runat="server">
 </asp:Content>
<asp:Content ID="cartContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BoutiqueConnectionString %>" DeleteCommand="DELETE FROM [tblCart] WHERE [UserId] = @original_UserId AND [ProductId] = @original_ProductId"
          InsertCommand="INSERT INTO [tblCart] ([UserId], [ProductId], [Quantity], [AddedDate]) VALUES (@UserId, @ProductId, @Quantity, @AddedDate)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT c.UserId, c.ProductId, p.ImageUrl, c.Quantity, p.Price FROM tblCart AS c INNER JOIN tblProduct AS p ON p.ProductID = c.ProductId WHERE (c.UserId = @UserId) AND (p.Active = 1)" 
          UpdateCommand="UPDATE [tblCart] SET [Quantity] = @Quantity, [AddedDate] = @AddedDate WHERE [UserId] = @UserId AND [ProductId] = @ProductId">
        <DeleteParameters>
            <asp:Parameter Name="original_UserId" Type="Int32" />
            <asp:Parameter Name="original_ProductId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="UserId" Type="Int32" />
            <asp:Parameter Name="ProductId" Type="Int32" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter DbType="Date" Name="AddedDate" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="UserId" SessionField="userid" />             
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="original_UserId" Type="Int32" />
            <asp:Parameter Name="original_ProductId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="UserId,ProductId" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">
            <AlternatingItemTemplate>
                <tr style="">                    
                      <td>
                        <asp:HiddenField ID="ProductIdLabel" runat="server" Value='<%# Eval("ProductId") %>' />
                    </td>
                    <td>
                        <asp:Image ID="ImageUrlLabel" Width="400" Height="400" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' /> 
                    </td>
                    <td>
                        <asp:label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>'></asp:label>
                    </td>
                    <td>
                        <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                    </td>
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="">                   
                     <td>
                        <asp:HiddenField ID="ProductIdLabel" runat="server" Value='<%# Eval("ProductId") %>' />
                    </td>
                    <td>
                        <asp:Image ID="ImageUrlLabel" Width="400" Height="400" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' /> 
                    </td>
                    <td>
                        <asp:TextBox ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                    </td>
                     <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td> No items found in your cart </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="UserIdTextBox" runat="server" Text='<%# Bind("UserId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ProductIdTextBox" runat="server" Text='<%# Bind("ProductId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ImageUrlTextBox" runat="server" Text='<%# Bind("ImageUrl") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="">                   
                    <td>
                        <asp:HiddenField ID="ProductIdLabel" runat="server" Value='<%# Eval("ProductId") %>' />
                    </td>
                    <td>
                        <asp:Image ID="ImageUrlLabel" Width="400" Height="400" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' /> 
                    </td>
                    <td>
                        <asp:label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>'></asp:label>
                    </td>
                    <td>
                        <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                    </td>
                     <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />                        
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                        <th runat="server"></th>
                                    <th runat="server"></th>
                                    <th runat="server">Quantity</th>
                                    <th runat="server">Price</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">                    
                    <td>
                        <asp:HiddenField ID="ProductIdLabel" runat="server" Value='<%# Eval("ProductId") %>' />
                    </td>
                    <td>
                        <asp:Image ID="ImageUrlLabel" Width="400" Height="400" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' /> 
                    </td>
                    <td>
                        <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                    </td>
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </td>
                </tr>
            </SelectedItemTemplate>
    </asp:ListView>
        <br />
</asp:Content>