using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JewelleryDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        int pid=int.Parse(Request.QueryString["pid"]);
        ProductId.Value = pid.ToString();
        ProductBLL prodbll = new ProductBLL();
        Product product = prodbll.GetAProduct(pid);
        ProductImg.Src = product.ImageUrl;
        ProductName.InnerText =product.Name;
        ProductDesc.InnerText = product.Description;
        ProductPrice.InnerText = "$"+product.Price.ToString();
        Session["prevUrl"] = Request.Url.AbsoluteUri;
    }

    protected void btnAddToCart_ServerClick(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            Response.Redirect("frmLogin.aspx");
        }
        else
        {
            Cart oCart = new Cart();
            oCart.product1.ProductId = int.Parse(ProductId.Value);
            oCart.UserId = int.Parse(Session["userid"].ToString());
            oCart.Quantity = 1;
            oCart.AddedDate = DateTime.Today;
            CartBLL cartBLL = new CartBLL();
            bool status = cartBLL.addCart(oCart);
            if (!status)
            {
                string message = "Product already exists in cart";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
        }
    }
    private void Page_Error(object sender, EventArgs e)
    {
        // Get last error from the server.
        Exception exc = Server.GetLastError();

        // Handle specific exception.
        if (exc is InvalidOperationException)
        {
            // Pass the error on to the error page.
            Server.Transfer("ErrorPage.aspx?handler=Page_Error%20-%20Default.aspx",
                true);
        }
        if (exc != null)
        {
            // Pass the error on to the error page.
            Server.Transfer("ErrorPage.aspx?handler=Page_Error%20-%20Default.aspx",
                true);
        }
    }
}