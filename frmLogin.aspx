<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLogin.aspx.cs" Inherits="Admin_Login" MasterPageFile="~/MasterTemplate.master"%>
<asp:Content ID="adminloginhead" ContentPlaceHolderID="head" runat="server">
    <style>
      body {
  background: #eee !important;
}

.wrapper {
  margin-top: 80px;
  margin-bottom: 80px;
  width:30%;
  margin: 0 auto;
}

.form-signin {
  max-width: 380px;
  padding: 15px 35px 45px;
  margin: 0 auto;
  background-color: #fff;
  border: 1px solid rgba(0, 0, 0, 0.1);
}
.form-signin .form-signin-heading,
.form-signin .checkbox {
  margin-bottom: 30px;
}
.form-signin .checkbox {
  font-weight: normal;
}
.form-signin .form-control {
  position: relative;
  font-size: 16px;
  height: auto;
  padding: 10px;
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
}
.form-signin .form-control:focus {
  z-index: 2;
}
.form-signin input[type="text"] {
  margin-bottom: -1px;
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}
.form-signin input[type="password"] {
  margin-bottom: 20px;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
}
    </style>
</asp:Content>
<asp:Content ID="adminlogin" ContentPlaceHolderID="MainContent" runat="server">

     <br/>
     <div class="wrapper" >       
      <h2 class="form-signin-heading">Login</h2>
      <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Please fix the following errors"
         ShowSummary="true" validationgroup="login" ForeColor="Red" runat="server" />
      <input type="email" class="form-control" id="email" placeholder="Email" required="required" autofocus="autofocus" runat="server"/>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" Display="None" validationgroup="login" runat="server" ErrorMessage="Please enter your registered email" ControlToValidate="email"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" validationgroup="login" ControlToValidate="email" ErrorMessage="Please enter valid email(e.g. user@gmail.com)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
      <br/>
      <input type="password" class="form-control" id="password" placeholder="Password" required="" runat="server"/> 
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" validationgroup="login" ForeColor="Red" Display="None" runat="server" ErrorMessage="Please enter password" ControlToValidate="password"></asp:RequiredFieldValidator>     
       <asp:RegularExpressionValidator ID="RegularExpressionValidator3"  validationgroup="login" runat="server" ControlToValidate="password" Display="None" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,10}$" ErrorMessage="Length should be 8 to 10 with atleast one special character, a number and an alphabet"></asp:RegularExpressionValidator>
      <br/>
           
      <button class="btn btn-lg btn-primary btn-block" id="btnLogin" type="submit" runat="server" OnServerClick="btnLogin_Click">Login</button>   
      <br/>
      <div>
      <a href="frmForgotPassword.aspx"  id="forgotPassword"  runat="server">Forgot Password</a> &nbsp &nbsp &nbsp
      New Customer?<a href="frmNewCustomer.aspx"  id="register"  runat="server">Register Here</a>
      </div>
     </div>
  
</asp:Content>