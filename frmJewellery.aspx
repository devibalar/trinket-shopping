<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmJewellery.aspx.cs" Inherits="Jewellery"  MasterPageFile="~/MasterTemplate.master" %>

  <asp:Content ID="jewellerieshead" ContentPlaceHolderID="head" runat="server">
      <style>
        .panel-footer {
            text-align:center;
        }
        .test-div-inner {
            padding-bottom:100%;
            background:#EEE;
            height:0;
            position:relative;
        }
        .test-image {
            width:100%;
            height:100%;
            display:block;
            position:absolute;
            min-width:200px;
        }
          .col-sm-4 {
              border-style:solid;
              border-color:#ffcee6;
              border-width:.5px;
              margin:8px;
              padding:0px; 
              max-width:400px;     
              position:relative;         
          }
          .products {
            margin:0 auto;
          }
     </style>
  </asp:Content>
  <asp:Content ID="jewelleriesContent" ContentPlaceHolderID="MainContent" runat="server">
      <br />
      <asp:HiddenField ID="ProductTypeId" runat="server" />
      <div class="container-fluid">   
          
              <asp:DataList ID="JewelleryList" runat="server" DataSourceID="ObjectDSProducts" CssClass="products" RepeatColumns="1"  RepeatLayout="Flow" RepeatDirection ="Horizontal" CellPadding="4" ForeColor="#333333" >                                                     
                  <AlternatingItemStyle BackColor="White" />
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <ItemStyle BackColor="#EFF3FB" />
                <ItemTemplate >                                        
                    <a href="frmJewelleryDetails.aspx?pid=<%# Eval("ProductId") %>">
                    <div class="col-sm-4">
                    <div class="news_img">                                             
                            <div class="test-div-inner">                
                            <img alt='<%# Eval("Name") %>' src='<%# Eval("ImageUrl") %>' class=".test-image img-responsive center-block" style="width:100%"/>
                            </div>  
                    </div>                  
                    <div class="panel-footer"><%# Eval("Name") %> <br/> $<%# Eval("Price") %></div>  
                    </div>   
                    </a>
                    <asp:HiddenField ID="ProductIDHidden" Value='<%# Eval("ProductId") %>' runat="server" />                                                                                                                                        
                </ItemTemplate>                                                               
                  <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <SeparatorStyle BorderStyle="Solid" />
              </asp:DataList>
          </div>
      <asp:ObjectDataSource ID="ObjectDSProducts" runat="server" SelectMethod="GetProducts" TypeName="ProductBLL" >
          <SelectParameters>
              <asp:QueryStringParameter DefaultValue="Earring" Name="type" QueryStringField="type" Type="String" />
          </SelectParameters>
</asp:ObjectDataSource>
  </asp:Content>

