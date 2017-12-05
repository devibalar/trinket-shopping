using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmUserActivation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["code"] != null && Request.QueryString["email"] != null)
        {
            UserBLL userBll = new UserBLL();
            UserActivation userActivation = new UserActivation();
            userActivation.Email = Request.QueryString["email"];
            userActivation.ActivationCode = Request.QueryString["code"];
            bool status = userBll.activateUser(userActivation);
            if (status)
            {
                string script = "window.onload = function(){ alert('";
                script += "Your account is active now. Enjoy shopping ";
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                //Response.Redirect("/Trinkets/frmHome.aspx");
            }
            else
            {
                string script = "window.onload = function(){ alert('";
                script += "Invalid link";
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "Failed", script, true); 
            }
        }
        else
        {
            string script = "window.onload = function(){ alert('";
            script += "Invalid link";
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "Failed", script, true); 
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