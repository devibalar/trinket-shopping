<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmExistingUser.aspx.cs" EnableEventValidation = "false" Inherits="Admin_ExistingCustomer" MasterPageFile="~/Admin/AdminTemplate.master" %>
<asp:Content ID="ExistingCustomerHead" ContentPlaceHolderID="ChildHead" runat="server">
</asp:Content>
<asp:Content ID="ExistingCustomerContent" ContentPlaceHolderID="ChildContent" runat="server">
      <br />
    <div class="row">
        <div class="col-sm-8">           
           <div class="row">      
               <div class="col-sm-5">
                   <label>Email</label>
               </div>
               <div class="col-sm-7">
                   <input id="SearchEmail" type="text"  runat="server"/>
               </div>
          </div>
          <br />
          <div class="row">                
            <div class="col-sm-12">
                <input id="SearchAdmin" type="checkbox" name="admin" value="admin" checked="checked"  runat="server"/>Admin
            </div>
          </div>
          <br />
          <div class="row"> 
             <div class="col-sm-5"></div>
             <div class="col-sm-7">
                <button id="btnSearchUser" type="submit" CausesValidation="false" runat="server" DataSourceID="SqlDataSource1" onserverclick="btnSearchUser_ServerClick" >Search</button>
             </div>
          </div>
          <br />    
          <div class="row"> 
          <div class="col-sm-12">
            <asp:GridView ID="UserList" runat="server"  BorderStyle="Solid" CellPadding="3"  OnSelectedIndexChanged="UserList_SelectedIndexChanged"        
                SelectedIndex="0" AllowPaging="True" ShowHeaderWhenEmpty="True" OnPageIndexChanging="UserList_OnPageIndexChanging" 
                OnRowDataBound="UserList_RowDataBound" SelectedRowStyle-BackColor="Silver" BorderWidth="1px" BorderColor="#999999" PagerSettings-PageButtonCount="15" 
                PagerStyle-HorizontalAlign="Center" PagerStyle-BorderWidth="4px" HeaderStyle-BorderWidth="4px" HorizontalAlign="Center" Width="300px" BackColor="White"
                ForeColor="Black" GridLines="Vertical">
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
        </div>      
     </div>

         <!--Edit selected user-->
   <div class="col-sm-4">
    <asp:ValidationSummary ID="ValidationSummary1"  HeaderText="Please fix the following errors"
         ShowSummary="true" ForeColor="Red" runat="server" validationgroup="UpdateUser"/>
       <asp:HiddenField ID="UserId" runat="server" />
    <div class="row">      
        <div class="col-sm-4">
            <label>First Name</label>
        </div> 
        <div class="col-sm-8">
        <input id="FirstName" disabled="disabled" type="text" class="form-control" placeholder="First Name" runat="server"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" validationgroup="UpdateUser" runat="server" ErrorMessage="Please enter First Name" ControlToValidate="FirstName" Display="None"></asp:RequiredFieldValidator>
        </div>
    </div>
        <br /> 
     <div class="row">  
        <div class="col-sm-4">
            <label>Last Name</label>
        </div> 
        <div class="col-sm-8">
             <input id="LastName" disabled="disabled" type="text" class="form-control" placeholder="Last Name" runat="server"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" validationgroup="UpdateUser" runat="server" ErrorMessage="Please enter Last Name" ControlToValidate="LastName" Display="None"></asp:RequiredFieldValidator>          
        </div>
      </div>    
      <br />  
    <div class="row">  
    <div class="col-sm-4">
        <label>Email</label>
    </div> 
    <div class="col-sm-8">
        <input id="Email" type="email" class="form-control" placeholder="Email" disabled="disabled" runat="server"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" validationgroup="UpdateUser" runat="server" ErrorMessage="Please enter Email" ControlToValidate="Email" Display="None"></asp:RequiredFieldValidator>      
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" validationgroup="UpdateUser" Display="None" ControlToValidate="Email" runat="server"  ErrorMessage="Please enter valid email(e.g. user@gmail.com)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    </div>
    </div>
    <br />
    <div class="row">  
    <div class="col-sm-4">
        <label>Phone</label>
    </div> 
    <div class="col-sm-8">
        <input id="Phone" type="text" class="form-control" placeholder="Phone" disabled="disabled" runat="server"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" validationgroup="UpdateUser" runat="server" ErrorMessage="Please enter Phone" ControlToValidate="Phone" Display="None"></asp:RequiredFieldValidator>      
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="None" validationgroup="UpdateUser" ControlToValidate="Phone" runat="server" ValidationExpression="^[0-9]{4,10}$" ErrorMessage="Phone number should contain only numbers"></asp:RegularExpressionValidator>
    </div>
    </div>
    <br />
    <div class="row">  
    <div class="col-sm-4">
        <label>Address</label>
    </div> 
    <div class="col-sm-8">
        <textarea id="Address" type="text" class="form-control" placeholder="Address" disabled="disabled" runat="server"></textarea>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" validationgroup="UpdateUser" runat="server" ErrorMessage="Please enter Address" ControlToValidate="Address" Display="None"></asp:RequiredFieldValidator>      
    </div>
    </div>
    <br />
     <div class="row">  
          <div class="col-sm-6">
              <button id="btnUpdateUser" validationgroup="UpdateUser" type="submit" runat="server" onserverclick="btnUpdateUser_ServerClick" style="float:right;">Update User</button>
          </div>
          <div class="col-sm-6">
              <button id="btnDeleteUser" type="submit" runat="server" onserverclick="btnDeleteUser_ServerClick" onclick="if ( !confirm('Are you sure you want to delete this user?')) return false;">Delete User</button>
          </div>
    </div>
       <br />
    <div class="row">  
       <div class="col-sm-6">
              <button id="btnDisableUser" type="submit" runat="server" onserverclick="btnDisableUser_ServerClick" onclick="if ( !confirm('Are you sure you want to disable this user?')) return false;">Disable User</button>
          </div>
        <div class="col-sm-6">
            </div>
     </div>
  </div>   
 </div>
 
</asp:Content>