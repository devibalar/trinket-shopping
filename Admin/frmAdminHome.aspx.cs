using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null || Session["userid"].ToString().Length<=0)
        {
            Server.Transfer("/Trinkets/ErrorPage.aspx?msg=401&handler=customErrors%20section%20-%20Web.config");            
        }
        else if (Session["admin"] != null && !Boolean.Parse(Session["admin"].ToString()))
        {
            Server.Transfer("/Trinkets/ErrorPage.aspx?msg=403&handler=customErrors%20section%20-%20Web.config");
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