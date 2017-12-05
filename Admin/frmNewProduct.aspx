<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmNewProduct.aspx.cs" Inherits="Admin_NewProduct"  MasterPageFile="~/Admin/AdminTemplate.master" %>
<asp:Content ID="NewProductHead" ContentPlaceHolderID="ChildHead" runat="server">
   <link type="text/css" rel="stylesheet" href="/Trinkets/css/Product.css" />
    <script type="text/javascript" src="/Trinkets/js/Product.js"></script>
</asp:Content>
<asp:Content ID="NewProductContent" ContentPlaceHolderID="ChildContent" runat="server">
    <br />  
    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="NProductGrp" HeaderText="Please fix the following errors"
         ShowSummary="true" ForeColor="Red" runat="server" ></asp:ValidationSummary>    
    <div class="row">
        <div class="col-sm-2">
          <label>Category</label>
         </div>
        <div class="col-sm-5">
             <select id="Category" class="form-control" placeholder="Category" required="required" runat="server" ></select>
        </div>
         <div class="col-sm-5"></div>
    </div>
    <br/>
     <div class="row"> 
        <div class="col-sm-2">
            <label>Product Name</label>
        </div>
         <div class="col-sm-5">
             <input id="ProductName" type="text" class="form-control" placeholder="Product Name" required="required" runat="server"/>
        </div>
         <div class="col-sm-5"><asp:RequiredFieldValidator ValidationGroup="NProductGrp" ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Please enter Product Name" Display="None" ControlToValidate="ProductName"></asp:RequiredFieldValidator></div>
     </div>
    <br/>
    <div class="row"> 
        <div class="col-sm-2">
            <label>Price</label>
         </div>
        <div class="col-sm-5">
         <input id="Price" type="number" class="form-control" placeholder="Price" min="1" required="required" runat="server"/>
        </div>
        <div class="col-sm-5">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="NProductGrp" runat="server"  ForeColor="Red" ErrorMessage="Please enter Price" Display="None" ControlToValidate="Price"></asp:RequiredFieldValidator>           
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" ValidationGroup="NProductGrp" runat="server" ValidationExpression="^\d{0,8}(\.\d{0,4})?$" ControlToValidate="Price" ErrorMessage="Please enter only numbers"></asp:RegularExpressionValidator>        
        </div>
    </div>
    <br/>

    <div class="row">
       <div class="col-sm-2">
           <label>Quantity</label>
       </div>   
       <div class="col-sm-5"> 
           <input id="Quantity" type="number" class="form-control" min="1" placeholder="Quantity" required="required" runat="server"/>
        </div>
        <div class="col-sm-5">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="NProductGrp" ForeColor="Red" ErrorMessage="Please enter Quantity" Display="None" ControlToValidate="Quantity"></asp:RequiredFieldValidator>            
            <asp:RangeValidator ID="RangeValidator1" runat="server" Display="None" ForeColor="Red" ValidationGroup="NProductGrp" ControlToValidate="Quantity" MinimumValue="1" MaximumValue="10000" ErrorMessage="Quantity should be between 1 and 10000"></asp:RangeValidator>
        </div>
    </div>
    <br/>
    <div class="row">
        <div class="form-group">
            <div class="col-sm-2">
            <label>Upload Image</label>
            </div>
            <div class="col-sm-5"> 
            <div class="input-group">
                <span class="input-group-btn">
                    <span class="btn btn-default btn-file">
                        Browse..<input type="file" id="ProductImage" accept=".png,.jpg,.jpeg" runat="server"/>
                    </span>
                </span>
                <input id="imgurl" type="text" class="form-control" readonly="readonly" required="required" runat="server"/>
            </div>
            <img id="img-upload"/>
           </div>
            <div class="col-sm-5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="NProductGrp" runat="server"  ForeColor="Red" ErrorMessage="Please select image" Display="None" ControlToValidate="imgurl"></asp:RequiredFieldValidator>
            </div>
      </div>   
   </div>   
    <br />
    <div class="row">
    <div class="col-sm-2">
        <label>Description</label>
    </div>   
    <div class="col-sm-5"> 
        <textarea id="Description"   class="form-control" placeholder="Description" runat="server" required="required"></textarea>
    </div>
    <div class="col-sm-5">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="NProductGrp" runat="server"  ForeColor="Red" ErrorMessage="Please enter description" Display="None" ControlToValidate="Description"></asp:RequiredFieldValidator></div>
     </div>
    <br/>
    
    <div class="row">
      <div class="col-sm-2"></div>
      <div class="col-sm-5">     
            <button id="AddProduct" type="submit" runat="server" ValidationGroup="NProductGrp" onserverclick="btnAddProduct_Click">Add Product</button>
      </div>
      <div class="col-sm-5"> </div>
    </div>
</asp:Content>
