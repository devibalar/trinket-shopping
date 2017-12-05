using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NewProduct : System.Web.UI.Page
{
    ProductTypeBLL typebll = new ProductTypeBLL();
    ProductBLL prodbll = new ProductBLL();
    Product prod = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null || Session["userid"].ToString().Length <= 0)
        {
            Server.Transfer("/Trinkets/ErrorPage.aspx?msg=401&handler=customErrors%20section%20-%20Web.config");
        }
        else if (Session["admin"] != null && !Boolean.Parse(Session["admin"].ToString()))
        {
            Server.Transfer("/Trinkets/ErrorPage.aspx?msg=403&handler=customErrors%20section%20-%20Web.config");
        }
        else
        {
            if (!IsPostBack)
            {
                DataSet ds = typebll.GetAllCategories();
                Category.DataSource = ds;
                Category.DataTextField = "Name";
                Category.DataValueField = "TypeId";
                Category.DataBind();
            }
        }
    }

    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        prod = new Product();
        prod.Name = ProductName.Value;
        prod.Price = Decimal.Parse(Price.Value);
        prod.Description = Description.Value;
        prod.TypeId = int.Parse(Category.Value);
        int quantity = int.Parse(Quantity.Value);      
        for (var i = 0; i < Request.Files.Count; i++)
        {
            var postedFile = Request.Files[i]; 
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                string fname = Path.GetFileName(postedFile.FileName);
                string subfolderName = prod.TypeId.ToString().ToLower();
                postedFile.SaveAs(Server.MapPath(Path.Combine("../image/" + subfolderName + "/", fname)));
                prod.ImageUrl = "image\\" + subfolderName+"\\" + fname;
            }
        }
        bool isAdded = prodbll.addProduct(prod, quantity);
        if (isAdded)
        {
            string message = "Product details have been added successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true); 
        }
        Response.Redirect("frmNewProduct.aspx");
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