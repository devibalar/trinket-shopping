<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmContact.aspx.cs" Inherits="frmContact" MasterPageFile="~/MasterTemplate.master" %>
<asp:Content ID="contactHead" ContentPlaceHolderID="head" runat="server">
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="http://cdnjs.cloudflare.com/ajax/libs/html5shiv/3.7/html5shiv.js"></script>
      <script src="http://cdnjs.cloudflare.com/ajax/libs/respond.js/1.3.0/respond.js"></script>
    <![endif]-->
    <style>
      #map-container { height: 300px }
        h2 {
        text-align:center;
        }       
    </style>
</asp:Content>
<asp:Content ID="contactContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container-fluid well well-lg" >
            <div class="row">
                <div class="col-xs-6 col-sm-6">
                     <div class="row">         
                     <div class="col-xs-9 col-sm-9">
                    <h2>Get In Touch</h2>
                     </div>         
                     </div>
                    <div class="form-group">
                        <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Please fix the following errors"
         ShowSummary="true" ForeColor="Red"  ValidationGroup="Contact" runat="server" />
                     <div class="row">         
                     <div class="col-xs-12 col-sm-12">
                          <label for="name">Name</label><input type="text" class="form-control" id="name" runat="server"/>
                         <asp:RequiredFieldValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="name" Display="None" ForeColor="Red" ValidationGroup="Contact" ErrorMessage="Please enter your name"></asp:RequiredFieldValidator>
                     </div> 
                     </div>
                     <div class="row">
                     <div class="col-xs-12 col-sm-12">
                          <label for="email">Email</label><input type="email" class="form-control" id="email" runat="server"/>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="email" Display="None" ForeColor="Red" ValidationGroup="Contact" ErrorMessage="Please enter your name"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" validationgroup="Contact" runat="server" ControlToValidate="email" Display="None" ErrorMessage="Please enter valid email(e.g. user@gmail.com)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     </div> 
                     </div>
                     <div class="row">
                     <div class="col-xs-12 col-sm-12">
                          <label for="subject">Subject</label><input type="text" class="form-control" id="subject" runat="server"/>
                         <asp:RequiredFieldValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="subject" Display="None" ForeColor="Red" ValidationGroup="Contact" ErrorMessage="Please enter subject"></asp:RequiredFieldValidator>
                     </div> 
                     </div>
                     <div class="row">
                     <div class="col-xs-12 col-sm-12">
                          <label for="queries">Queries</label><textarea  class="form-control" id="queries" runat="server"></textarea>
                         <asp:RequiredFieldValidator ID="RegularExpressionValidator4" runat="server"  ControlToValidate="queries" Display="None" ForeColor="Red" ValidationGroup="Contact" ErrorMessage="Please enter your queries"></asp:RequiredFieldValidator>
                     </div> 
                     </div>
                    <br />
                <div class="row">
                   &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<button id="Submit" type="submit" runat="server" onserverclick="btnSubmit_Click">Submit</button>        
                </div>
                </div>
            </div>
             <div class="col-sm-2">
             </div>
            <div class="col-sm-3">
                <div class="row">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12">
                        <h2 style="text-align:left"> Contact Info</h2>
                        </div>
                    </div>
                    <br /><br />
                    <div class="row">
                        <div class="col-xs-2 col-sm-2">   
                            <span class="glyphicon glyphicon-map-marker"></span>
                         </div>
                         <div class="col-xs-10 col-sm-10">        
                            Sylvia Park, <br/>  
                            Mount Wellington Highway,<br />
                            Auckland<br />                   
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-xs-2 col-sm-2">
                            <span class="glyphicon glyphicon-earphone"></span>
                        </div>
                        <div class="col-xs-10 col-sm-10">
                         064-2355667
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-xs-2 col-sm-2">
                           <span class="glyphicon glyphicon-envelope"></span> 	
                        </div>
                        <div class="col-xs-10 col-sm-10">
                            trinketsnz@gmail.com
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        <img src="/Trinkets/image/contact/facebook.png" alt="facebook"/>
                        <img src="/Trinkets/image/contact/twitter.png" alt="twitter"/>
                        <img src="/Trinkets/image/contact/googleplus.png" alt="googleplus"/>
                        <img src="/Trinkets/image/contact/linkedin.png" alt="linkedin"/>
                        <img src="/Trinkets/image/contact/youtube.png" alt="youtube"/>
                        <img src="/Trinkets/image/contact/skype.png" alt="skype"/>
                    </div>
                </div>
            </div> 
        </div>
    </div>
    <div class="container">
      <div id="map-container" class="col-xs-11 col-sm-11">
              <script src="http://maps.google.com/maps/api/js?key=AIzaSyAGHCTRiHxY58Usy_WqV5hWs6lU6pCO67A&sensor=false"></script>
              <script src="/Trinkets/js/Contact.js"></script>         
      </div>
    </div>
      
</asp:Content>
