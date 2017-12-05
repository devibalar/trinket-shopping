using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
public partial class Admin_ExistingProduct : System.Web.UI.Page
{
    ProductBLL prodBLL = new ProductBLL();
    ProductTypeBLL typebll = new ProductTypeBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
       /* if (Session["userid"] == null || Session["userid"].ToString().Length <= 0)
        {
            Server.Transfer("/Trinkets/ErrorPage.aspx?msg=401&handler=customErrors%20section%20-%20Web.config");
        }
        else if (Session["admin"] != null && !Boolean.Parse(Session["admin"].ToString()))
        {
            Server.Transfer("/Trinkets/ErrorPage.aspx?msg=403&handler=customErrors%20section%20-%20Web.config");
        }
        else
        {*/
            if (!IsPostBack)
            {
                DataSet ds = typebll.GetAllCategories();
                Category.DataSource = ds;
                Category.DataTextField = "Name";
                Category.DataValueField = "TypeId";
                Category.DataBind();
            }
            else
            {
                this.BindGrid();
            }
      //  }
    }
    protected void btnSearchProduct_Click(object sender, EventArgs e)
    {
        this.BindGrid();
        EditName.Disabled = false;
        EditDescription.Disabled = false;
        EditPrice.Disabled = false;
        EditQuantity.Disabled = false;
        imgText.Disabled = false;
        ProductImage.Disabled = false;
    }
    private void BindGrid()
    {
        int typeId = int.Parse(Category.Value);
        string prodName = ProductName.Value.Trim();
        decimal priceFrom =0 ;
        decimal priceTo =0 ;
        // if only product name is given in search
        if (prodName.Length <= 0 && (FromPrice.Value == null || FromPrice.Value.Length < 0 || ToPrice.Value == null || ToPrice.Value.Length < 0)) 
        {
            DataTable dt = prodBLL.GetAllProducts(typeId, prodName);
            ProductList.DataSource = dt;
            ProductList.DataBind();
        }
        else if ((FromPrice.Value != null && FromPrice.Value.Length > 0) || (ToPrice.Value != null && ToPrice.Value.Length > 0))// if price is given in search
        {
            if(FromPrice.Value != null)
            {
                priceFrom = Decimal.Parse(FromPrice.Value);
            }
            if (ToPrice.Value != null)
            {
                priceTo = Decimal.Parse(ToPrice.Value);
            }
             DataTable dt = prodBLL.GetAllProducts(typeId, prodName, priceFrom, priceTo );
             ProductList.DataSource = dt;
             ProductList.DataBind();
        }
        else
        {
            DataTable dt = prodBLL.GetAllProducts(typeId);
            ProductList.DataSource = dt;
            ProductList.DataBind();           
        }
    }

    protected void ProductList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ProductList.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    protected void ProductList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(ProductList, "Select$" + e.Row.RowIndex.ToString());
            e.Row.Attributes.Add("onMouseOver", "this.previous_color=this.style.backgroundColor;this.style.backgroundColor='Silver'");
            e.Row.Attributes.Add("onMouseOut", "this.style.background=this.previous_color;");
        }        
    }
    protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
    {       
            int prodId = int.Parse(ProductList.SelectedRow.Cells[0].Text);
            string prodName = ProductList.SelectedRow.Cells[1].Text;
            decimal prodPrice = Decimal.Parse(ProductList.SelectedRow.Cells[2].Text);
            string prodDesc = ProductList.SelectedRow.Cells[3].Text;
            string prodImag = ProductList.SelectedRow.Cells[4].Text;
            int quantity = int.Parse(ProductList.SelectedRow.Cells[5].Text);
            EditName.Value = prodName;
            EditPrice.Value = prodPrice.ToString();
            EditDescription.Value = prodDesc;
            EditQuantity.Value = quantity.ToString();
            imgText.Value = Path.GetFileName(prodImag); 
            EditProductId.Value = prodId.ToString();
       
    }
    protected void btnUpdateProduct_Click(object sender, EventArgs e)
    {
       
            Product prod = new Product();
            prod.ProductId = int.Parse(EditProductId.Value);
            prod.Name = EditName.Value;
            prod.Price = Decimal.Parse(EditPrice.Value);
            prod.Description = EditDescription.Value;
            int quantity = int.Parse(EditQuantity.Value);
            for (var i = 0; i < Request.Files.Count; i++)
            {
                var postedFile = Request.Files[i];
                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    string fname = Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(Server.MapPath(Path.Combine("../image/", fname)));
                    prod.ImageUrl = "image\\" + fname;
                }
                else
                {
                    prod.ImageUrl = "image\\" + imgText.Value;
                }
            }
            bool isUpdated = prodBLL.updateProduct(prod, quantity);
            if (isUpdated)
            {
                this.BindGrid();
                string message = "Product details have been updated successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true); 
            }
       
    }
    protected void btnDeleteProduct_Click(object sender, EventArgs e)
    {       
        int prodId = int.Parse(EditProductId.Value);
        bool isDeleted = prodBLL.deleteProduct(prodId);
        if (isDeleted)
        {
            this.BindGrid();
            string message = "Product details have been deleted successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            EditName.Value = "";
            EditDescription.Value = "";
            EditPrice.Value = "";
            EditQuantity.Value = "";
            imgText.Value = "";
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