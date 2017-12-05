<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation = "false" CodeFile="frmExistingProduct.aspx.cs" Inherits="Admin_ExistingProduct" MasterPageFile="~/Admin/AdminTemplate.master" %>
<asp:Content ID="ExistingProductHead" ContentPlaceHolderID="ChildHead" runat="server">
   <link type="text/css" rel="stylesheet" href="/Trinkets/css/Product.css" />
    <script type="text/javascript" src="/Trinkets/js/Product.js"></script>
</asp:Content>
<asp:Content ID="ExistingProductContent" ContentPlaceHolderID="ChildContent" runat="server">
    <br />
     <asp:ValidationSummary ID="ValidationSummary3"  HeaderText="Please fix the following errors"
         ShowSummary="true" ForeColor="Red" runat="server" ValidationGroup="SProductGrp" />
    <div class="row">
        <div class="col-sm-6">
     <div class="row">      
        <div class="col-sm-5">
          <label>Category</label>
        </div>
         <div class="col-sm-7">
          <select id="Category" class="form-control" placeholder="Category" runat="server"></select>
        </div>
       </div>
        <br /> 

     <div class="row">      
        <div class="col-sm-5">
            <label>Product Name</label>
        </div>
         <div class="col-sm-7">
            <input id="ProductName" class="form-control"  type="text"  runat="server"/>
         </div>
     </div>
     <br />
     <div class="row">  
        <div class="col-sm-2">
            <label>Price</label>
        </div> 
        <div class="col-sm-3">
             <input id="FromPrice" class="form-control"  width="10" type="text" runat="server"/>  
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" ValidationGroup="SProductGrp" runat="server" ValidationExpression="^\d{0,8}(\.\d{0,4})?$" ControlToValidate="FromPrice"  ErrorMessage="Please enter only numbers"></asp:RegularExpressionValidator>        
        </div>
         <div class="col-sm-2">
             <label>To</label>
         </div>
         <div class="col-sm-3">
            <input id="ToPrice" class="form-control" width="10" type="text" runat="server"/> 
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="None" ValidationGroup="SProductGrp" runat="server" ValidationExpression="^\d{0,8}(\.\d{0,4})?$" ControlToValidate="ToPrice"  ErrorMessage="Please enter only numbers"></asp:RegularExpressionValidator>                   
         </div>
      </div>
     <br />
     <div class="row"> 
         <div class="col-sm-5"></div>
         <div class="col-sm-7">
            <button id="SearchProduct"  type="submit" runat="server" onserverclick="btnSearchProduct_Click">Search</button>
         </div>
     </div>
    <br />
   </div>
    <!--Edit selected product-->
   <div class="col-sm-6">
    <asp:ValidationSummary ID="ValidationSummary1"  HeaderText="Please fix the following errors"
         ShowSummary="true" ForeColor="Red" runat="server" ValidationGroup="UProductGrp" />
    <div class="row">      
        <div class="col-sm-4">
            <label>Product Name</label>
        </div> 
        <div class="col-sm-8">
        <input id="EditName" disabled="disabled" type="text" class="form-control" placeholder="Product Name" runat="server"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ValidationGroup="UProductGrp" runat="server" ErrorMessage="Please enter Product Name" ControlToValidate="EditName" Display="None"></asp:RequiredFieldValidator>
        </div>
    </div>
        <br /> 
     <div class="row">  
        <div class="col-sm-4">
            <label>Price</label>
        </div> 
        <div class="col-sm-8">
             <input id="EditPrice" disabled="disabled" type="number" min="1" class="form-control" placeholder="Price" runat="server"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ValidationGroup="UProductGrp" runat="server" ErrorMessage="Please enter Price" ControlToValidate="EditPrice" Display="None"></asp:RequiredFieldValidator>          
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red" ValidationGroup="UProductGrp" runat="server" Display="None" ValidationExpression="^\d{0,8}(\.\d{0,4})?$" ControlToValidate="FromPrice"  ErrorMessage="Please enter only numbers"></asp:RegularExpressionValidator>
        </div>
      </div>    
      <br />
      <div class="row">  
        <div class="col-sm-4">
            <label>Quantity</label>
        </div> 
        <div class="col-sm-8">
            <input id="EditQuantity" disabled="disabled" type="number" class="form-control" min="1" placeholder="Quantity" runat="server"/>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ValidationGroup="UProductGrp" runat="server" ErrorMessage="Please enter Quantity" ControlToValidate="EditQuantity" Display="None"></asp:RequiredFieldValidator>                  
            <asp:RangeValidator ID="RangeValidator1" runat="server" ForeColor="Red" Display="None" ValidationGroup="UProductGrp" ControlToValidate="EditQuantity" MinimumValue="1" MaximumValue="10000" ErrorMessage="Quantity should be between 1 and 10000"></asp:RangeValidator>
            </div>
      </div>
      <br />
     <div class="row">  
        <div class="form-group">
            <div class="col-sm-4">
                <label>Upload Image</label>
            </div>
            <div class="col-sm
                -8">
            <div class="input-group">
                <span class="input-group-btn">
                    <span class="btn btn-default btn-file">
                        Browse..<input type="file" id="ProductImage" accept=".png,.jpg,.jpeg" disabled="disabled" runat="server"/>
                    </span>
                </span>
                <input id="imgText" type="text" class="form-control" readonly="readonly"  runat="server"/>
            </div>
            <img src="#" id="img-upload" /><asp:HiddenField ID="EditProductId" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ValidationGroup="UProductGrp" runat="server" ErrorMessage="Please select an image " ControlToValidate="imgText" Display="None"></asp:RequiredFieldValidator>      
        </div>
      </div>
    </div>
    <br />
    <div class="row">  
    <div class="col-sm-4">
        <label>Description</label>
    </div> 
    <div class="col-sm-8">
        <textarea id="EditDescription" class="form-control" placeholder="Description" disabled="disabled" runat="server"></textarea>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ValidationGroup="UProductGrp" runat="server" ErrorMessage="Please enter description" ControlToValidate="EditDescription" Display="None"></asp:RequiredFieldValidator>      
    </div>
    </div>
    <br />
     <div class="row">  
          <div class="col-sm-6">
              <button id="UpdateProduct" ValidationGroup="UProductGrp" type="submit" runat="server" onserverclick="btnUpdateProduct_Click" style="float:right;">Update Product</button>
          </div>
          <div class="col-sm-6">
              <button id="DeleteProduct"  type="submit" runat="server" onserverclick="btnDeleteProduct_Click" onclick="if ( !confirm('Are you sure you want to delete this product?')) return false;">Delete Product</button>
          </div>
     </div>
  </div>   
 </div>
<br />       
<div class="row"> 
    <div class="col-sm-5">
        <asp:GridView ID="ProductList" runat="server" BorderStyle="Solid" CellPadding="3"  OnSelectedIndexChanged="ProductList_SelectedIndexChanged" SelectedIndex="0" AllowPaging="True" ShowHeaderWhenEmpty="True" OnPageIndexChanging="ProductList_OnPageIndexChanging" OnRowDataBound="ProductList_RowDataBound" SelectedRowStyle-BackColor="Silver" BorderWidth="1px" BorderColor="#999999" PagerSettings-PageButtonCount="15" PagerStyle-HorizontalAlign="Center" PagerStyle-BorderWidth="4px" HeaderStyle-BorderWidth="4px" HorizontalAlign="Center" Width="600px" BackColor="White" ForeColor="Black" GridLines="Vertical">    
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BorderWidth="4px" HorizontalAlign="Center" BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>
        <PagerSettings PageButtonCount="15"></PagerSettings>
        <PagerStyle HorizontalAlign="Center" BorderWidth="4px" Height="800px" BackColor="#999999" ForeColor="Black"></PagerStyle>
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
   </div>
   <div class="col-sm-7">
   </div>
</div>
</asp:Content>
