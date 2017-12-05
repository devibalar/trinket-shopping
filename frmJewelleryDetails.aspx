<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmJewelleryDetails.aspx.cs" Inherits="JewelleryDetails" MasterPageFile="~/MasterTemplate.master"%>
<asp:Content ID="jewelhead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="jewelContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
            <br />
            <br />
            <div class="row">
            <div  class="col-sm-4" >
            <img id="ProductImg" class="img-responsive center-block" src="" alt=""  runat="server" />         
            </div>
            <div class="col-sm-8" >
                <div class="row">
                <div class="col-sm-9">
                <h2 id="ProductName"  runat="server" ></h2>
                </div>
                <div class="col-sm-3">
                <button id="btnAddToCart" style="margin-top:30px;padding:0; border:inherit" onserverclick="btnAddToCart_ServerClick" runat="server"><img src="image/AddToCart.png" style="padding:0" /></button>  
                </div> 
                </div>
                <hr />
                <p id="ProductPrice" runat="server"></p>
                <p id="ProductDesc" runat="server" ></p>    <asp:HiddenField ID="ProductId" runat="server" />
                <asp:HiddenField ID="UserId" runat="server" />
               </div>
            </div>  
        </div>    
</asp:Content>