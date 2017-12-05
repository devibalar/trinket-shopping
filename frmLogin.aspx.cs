using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetNoServerCaching();
        HttpContext.Current.Response.Cache.SetNoStore();
       
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string usremail = email.Value;
        string usrpwd = password.Value;
        UserBLL userbll = new UserBLL();
     /*   User oUser = userbll.validateUser(usremail, usrpwd);
        if (oUser == null)
        {
            string message = "Login Failed. Please enter valid email and password";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "Failed", script, true);
        }
        else
        {*/
        Session["admin"] = "admin";//oUser.IsAdmin;
        Session["userid"] = "userid";// oUser.UserId;
            Session["email"] = "email" ;//oUser.Email;

            if(true)//if (oUser.IsAdmin)
            {             
                Response.Redirect("/Trinkets/Admin/frmAdminHome.aspx");
            }
            else
            {
                ((System.Web.UI.HtmlControls.HtmlControl)this.Master.FindControl("liAcccount")).Visible = false;
                if (Session["prevUrl"] != null && Session["prevUrl"].ToString().Length > 0)
                {
                    Response.Redirect((string)Session["prevUrl"]);
                }
                else
                {
                    Response.Redirect("frmHome.aspx");
                }
            }            
        //}      
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