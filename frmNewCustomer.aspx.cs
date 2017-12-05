using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NewCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
   
    protected void AddCustomer_ServerClick(object sender, EventArgs e)
    {
       string message = "";
       string custFirstName=  FirstName.Value;
       string custLastName = LastName.Value;
       string custPassword = Password.Value;
       string custConfirmPassword = ConfirmPassword.Value;
       string custEmail = Email.Value;
       string custPhone = Phone.Value;
       string custAddress = Address.Value;
       User oUser = new User();
       oUser.FirstName = custFirstName;
       oUser.LastName = custLastName;
       oUser.Password = custPassword;
       oUser.Email = custEmail;
       oUser.Phone = custPhone;
       oUser.Address = custAddress;
       oUser.IsActive = false;
       oUser.IsAdmin = false; // this page is used for creating customers only 
       UserBLL oUserBLL = new UserBLL();
       bool status = oUserBLL.addUser(oUser);
       if (status)
       {
           message = "Registration completed successfully. We have sent a link to account your account. Please check your mail";         
       }
       else
       {
           message = "Registration failed. Contact Administrator";
       }
       string script = "window.onload = function(){ alert('";
       script += message;
       script += "')};";
       ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
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