<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmRestorePassword.aspx.cs" Inherits="RestorePassword" MasterPageFile="~/MasterTemplate.master" %>
<asp:Content ID="restorePasswordhead" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="restorePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
     <div class="container">
          <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Please fix the following errors"
             ShowSummary="true" ForeColor="Red" validationgroup="RestorePwd" runat="server" />
            <div class="row">
                <div class="col-sm-3">
                </div>
                <div class="col-sm-5">
                    <h2>Reset Password</h2>
                </div>
                <div class="col-sm-4"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                </div>
                <div class="col-sm-2">
                    <label>New Password</label>
                </div>
                 <div class="col-sm-3">
                    <input id="NewPassword" type="password" class="form-control" placeholder="New Password" required="required" runat="server"/>
                </div>
                <div class="col-sm-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" validationgroup="RestorePwd" ForeColor="Red" Display="None" runat="server" ErrorMessage="Please enter new password" ControlToValidate="NewPassword"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3"  validationgroup="RestorePwd" runat="server" ControlToValidate="NewPassword" Display="None" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,10}$" ErrorMessage="Length should be 8 to 10 with atleast one special character, a number and an alphabet"></asp:RegularExpressionValidator>
                </div>
           </div>
           <br />
           <div class="row">
                <div class="col-sm-3">
                </div>
                <div class="col-sm-2">
                    <label>Confirm Password</label>
                </div>
                 <div class="col-sm-3">
                    <input id="ConfirmPassword" type="password" class="form-control" placeholder="Confirm Password" required="required" runat="server"/>
                </div>
                <div class="col-sm-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" validationgroup="RestorePwd" ForeColor="Red" Display="None" runat="server" ErrorMessage="Please enter confirmation password" ControlToValidate="ConfirmPassword"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" validationgroup="RestorePwd" runat="server"  ErrorMessage="Does not match password" ControlToValidate="ConfirmPassword" ControlToCompare="NewPassword"></asp:CompareValidator>
                </div>
           </div>
           <br />
           <div class="row">
              <div class="col-sm-5"></div>
              <div class="col-sm-2">       
                  <button id="ChangePassword" type="submit" runat="server" onserverclick="ChangePassword_ServerClick">Change Password</button>
              </div>
              <div class="col-sm-4"> </div>
           </div>
     </div>
</asp:Content>
