<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmNewCustomer.aspx.cs" Inherits="Admin_NewCustomer" MasterPageFile="~/MasterTemplate.master" %>
<asp:Content ID="NewCustomerHead" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="NewCustomerContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Please fix the following errors"
         ShowSummary="true" ForeColor="Red" runat="server" validationgroup="AddCustomer"></asp:ValidationSummary> 
    <div class="row">
        <div class="col-sm-2"></div>
        <div class="col-sm-2">
          <label>First Name</label>
         </div>
        <div class="col-sm-5">
             <input id="FirstName" type="text" class="form-control" placeholder="First Name" required="required" runat="server"/>
        </div>
         <div class="col-sm-3"><asp:RequiredFieldValidator ID="RequiredFieldValidator6" validationgroup="AddCustomer" ForeColor="Red" runat="server" ErrorMessage="Please enter First Name" Display="None" ControlToValidate="FirstName"></asp:RequiredFieldValidator></div>
    </div>
    <br/>
     <div class="row"> 
         <div class="col-sm-2"></div>
        <div class="col-sm-2">
            <label>Last Name</label>
        </div>
         <div class="col-sm-5">
             <input id="LastName" type="text" class="form-control" placeholder="Last Name" required="required" runat="server"/>
        </div>
         <div class="col-sm-3">
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" validationgroup="AddCustomer" ForeColor="Red" runat="server" ErrorMessage="Please enter Last Name" Display="None" ControlToValidate="LastName"></asp:RequiredFieldValidator>
         </div>
     </div>
    <br/>
    <div class="row"> 
        <div class="col-sm-2"></div>
        <div class="col-sm-2">
            <label>Password</label>
        </div>
         <div class="col-sm-5">
             <input type="password" id="Password" class="form-control" placeholder="Password" required="required" runat="server"/>
        </div>
         <div class="col-sm-3">
             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" validationgroup="AddCustomer" ForeColor="Red" runat="server" ErrorMessage="Please enter your Password" Display="None" ControlToValidate="Password"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator3"  validationgroup="AddCustomer" runat="server" ControlToValidate="Password" Display="None" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,10}$" ErrorMessage="Length should be 8 to 10 with atleast one special character, a number and an alphabet"></asp:RegularExpressionValidator>
         </div>
     </div>
    <br />
      <div class="row"> 
        <div class="col-sm-2"></div>
        <div class="col-sm-2">
            <label>Confirm Password</label>
        </div>
         <div class="col-sm-5">
             <input type="password" id="ConfirmPassword" class="form-control" placeholder="Password" required="required" runat="server"/>
        </div>
         <div class="col-sm-3">
             <asp:RequiredFieldValidator ID="RequiredFieldValidator9" validationgroup="AddCustomer" ForeColor="Red" runat="server" ErrorMessage="Please enter your Confirmation Password" Display="None" ControlToValidate="ConfirmPassword"></asp:RequiredFieldValidator>
             <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="AddCustomer" ControlToValidate="ConfirmPassword" ControlToCompare="Password" Display="None" ErrorMessage="Confirmation password must match password in above field"></asp:CompareValidator>
         </div>
     </div>
    <br />  
      <div class="row"> 
        <div class="col-sm-2"></div>
        <div class="col-sm-2">
            <label>Email</label>
        </div>
         <div class="col-sm-5">
             <input type="email" id="Email" class="form-control" placeholder="Email" required="required" runat="server"/>
        </div>
         <div class="col-sm-3">
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" validationgroup="AddCustomer" ForeColor="Red" runat="server" ErrorMessage="Please enter your Email" Display="None" ControlToValidate="Email"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" validationgroup="AddCustomer" runat="server" ControlToValidate="Email" ErrorMessage="Please enter valid email(e.g. user@gmail.com)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
         </div>
     </div>
    <br/>
    <div class="row"> 
        <div class="col-sm-2"></div>
        <div class="col-sm-2">
            <label>Phone</label>
        </div>
         <div class="col-sm-5">
             <input type="text" id="Phone" class="form-control" placeholder="Phone" required="required" runat="server"/>
        </div>
         <div class="col-sm-3">
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" validationgroup="AddCustomer" ForeColor="Red" runat="server" ErrorMessage="Please enter your Phone" Display="None" ControlToValidate="Phone"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="None" validationgroup="AddCustomer" runat="server" ControlToValidate="Phone" ValidationExpression="^[0-9]{4,10}$" ErrorMessage="Phone number should contain only numbers"></asp:RegularExpressionValidator>
         </div>
     </div>
    <br/>
    <div class="row">
        <div class="col-sm-2"></div>
        <div class="col-sm-2">
            <label>Address</label>
        </div>   
        <div class="col-sm-5"> 
            <textarea id="Address" class="form-control" placeholder="Address" runat="server" required="required"></textarea>
        </div>
        <div class="col-sm-3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" validationgroup="AddCustomer" runat="server"  ForeColor="Red" ErrorMessage="Please enter Address" Display="None" ControlToValidate="Address"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br/>
    <div class="row">
      <div class="col-sm-2"></div>
      <div class="col-sm-5">       
          <button id="btnAddCustomer" type="submit" onserverclick="AddCustomer_ServerClick" validationgroup="AddCustomer" runat="server" >Register</button>
      </div>
      <div class="col-sm-5"> </div>
    </div>
</asp:Content>