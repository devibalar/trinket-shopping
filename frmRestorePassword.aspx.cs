using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RestorePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void ChangePassword_ServerClick(object sender, EventArgs e)
    {
        string resetKey = Request.QueryString["key"].ToString();
        UserBLL oUserBLL = new UserBLL();
        if(resetKey!=null)
        {
            User oUser = new User();
            oUser.ResetKey = resetKey;
            oUser.Password = NewPassword.Value;
            bool status = oUserBLL.removeResetPasswordKey(oUser);
            if (status)
            {
                string script = "window.onload = function(){ alert('";
                script += "Password has been reset successfully ";
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
        if (exc !=null)
        {
            // Pass the error on to the error page.
            Server.Transfer("ErrorPage.aspx?handler=Page_Error%20-%20Default.aspx",
                true);
        }
    }
}