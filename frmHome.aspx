<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmHome.aspx.cs" Inherits="Home" MasterPageFile="~/MasterTemplate.master" %>

    <asp:Content ID="homeHead" ContentPlaceHolderID="head" runat="server">
       
    <style>
          .carousel-inner img {
              width: 100%; /* Set width to 100% */
              margin: auto;
              min-height:200px;
              max-height:400px;
          }

          /* Hide the carousel text when the screen is less than 600 pixels wide */
          @media (max-width: 600px) {
            .carousel-caption {
              display: none; 
            }
          }
           .panel-footer {
            text-align:center;
          }
       
          
    </style>
    </asp:Content>
    <asp:Content ID="homeContent" ContentPlaceHolderID="MainContent" runat="server">
        <!-- Half Page Image Background Carousel Header -->
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
          <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
          <li data-target="#myCarousel" data-slide-to="1"></li>
          <li data-target="#myCarousel" data-slide-to="2"></li>
          <li data-target="#myCarousel" data-slide-to="3"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
          <div class="item active">
            <img src="/Trinkets/image/slider/slider01.jpg" alt="Image"/>
            <div class="carousel-caption">
              <h3>Classic and Fashionable</h3>
            </div>      
          </div>

          <div class="item">
            <img src="/Trinkets/image/slider/slider02.jpg" alt="Image"/>
            <div class="carousel-caption">
              <h3>Handmade jewels</h3>
            </div>      
          </div>
        
          <div class="item">
            <img src="/Trinkets/image/slider/slider03.png" alt="Image"/>
            <div class="carousel-caption">
              <h3>Royal and Enchanting</h3>
            </div>      
          </div>
        
          <div class="item">
            <img src="/Trinkets/image/slider/slider04.jpg" alt="Image"/>
            <div class="carousel-caption">
              <h3>Simple and Humble</h3>
            </div>      
          </div>
        </div>

        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
          <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
          <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
          <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
          <span class="sr-only">Next</span>
        </a>
    </div>
    
     <!-- Add Deals -->
         <h3 class="container-fluid text-center">  
             Today's deals
         </h3>
        <div class="container">            
          <div class="row">
            <div class="col-sm-4">
              <div class="panel panel-primary">
                <div class="panel-body"><img src="/Trinkets/image/ring/Ring12.jpg" class="img-responsive" style="width:100%" alt="Image"/></div>
                <div class="panel-footer">Order for more than $25 and get a gift voucher</div>
              </div>
            </div>
            <div class="col-sm-4"> 
              <div class="panel panel-primary">
                <div class="panel-body"><img src="/Trinkets/image/necklace/Necklace7.jpg" class="img-responsive" style="width:100%" alt="Image"/></div>
                <div class="panel-footer">Free matching earring for necklace of $30 or more</div>
              </div>
            </div>
            <div class="col-sm-4"> 
              <div class="panel panel-primary">
                <div class="panel-body"><img src="/Trinkets/image/earring/classicgolden11.jpg" class="img-responsive" style="width:100%" alt="Image"/></div>
                <div class="panel-footer">Latest Arrivals</div>
              </div>
            </div>
          </div>
        </div><br/><br/><br/>            
               
    </asp:Content>
