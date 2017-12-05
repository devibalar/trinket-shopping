using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetNoServerCaching();
        HttpContext.Current.Response.Cache.SetNoStore();
        Session["prevUrl"] = Request.Url.AbsoluteUri;
        if (Session["userid"] == null || !string.IsNullOrEmpty(Session["userid"] as string))
        {
            ((System.Web.UI.HtmlControls.HtmlControl)this.Master.FindControl("liLogin")).Visible = true;
            ((System.Web.UI.HtmlControls.HtmlControl)this.Master.FindControl("liAcccount")).Visible = false;
        }
        else
        {            
            ((System.Web.UI.HtmlControls.HtmlControl)this.Master.FindControl("liAcccount")).Visible = true;
            ((System.Web.UI.HtmlControls.HtmlControl)this.Master.FindControl("liLogin")).Visible = false;
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