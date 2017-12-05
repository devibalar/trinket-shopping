<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmForgotPassword.aspx.cs" Inherits="ForgotPassword" MasterPageFile="~/MasterTemplate.master" %>
<asp:Content ID="forgotPasswordhead" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="forgotPassword" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <br />
     <div class="container" >
         <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Please fix the following errors"
             ShowSummary="true" ForeColor="Red" runat="server" validationgroup="ForgotPwd"  />
          <div class="row">
            <div class="col-sm-3">
            </div>
            <div class="col-sm-5">
            <h2 class="form-signin-heading">Forgot Password</h2>
            </div>
            <div class="col-sm-4"></div>
         </div>
         <br />
         <div class="row"> 
            <div class="col-sm-3">
            </div>
            <div class="col-sm-2"> 
                <label>Email</label>
            </div>
             <div class="col-sm-3">    
                  <input type="email" class="form-control" id="email" placeholder="Email" required="required" autofocus="autofocus" runat="server"/>
             </div>
             <div class="col-sm-4">
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" validationgroup="ForgotPwd"  ForeColor="Red" Display="None" runat="server" ErrorMessage="Please enter your registered email" ControlToValidate="email"></asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" validationgroup="ForgotPwd" runat="server" ControlToValidate="email" ErrorMessage="Please enter valid email(e.g. user@gmail.com)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
             </div>
          </div>
          <br/>
          <div class="row"> 
            <div class="col-sm-5">
            </div>
            <div class="col-sm-2">                 
          <button class="btn btn-lg btn-primary btn-block" id="btnResetPassword" validationgroup="ForgotPwd"  type="submit" runat="server" OnServerClick="btnResetPassword_ServerClick">Reset Password</button>   
          </div>
           <div class="col-sm-5">  
           </div>
          <br/>
         </div>
     </div>
</asp:Content>