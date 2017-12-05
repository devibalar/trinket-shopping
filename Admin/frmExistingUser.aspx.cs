using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ExistingCustomer : System.Web.UI.Page
{
    UserBLL oUserBLL = new UserBLL();
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
            this.BindGrid();
        }
    }

      protected void UserList_RowDataBound(object sender, GridViewRowEventArgs e)
      {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
              e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(UserList, "Select$" + e.Row.RowIndex.ToString());
              e.Row.Attributes.Add("onMouseOver", "this.previous_color=this.style.backgroundColor;this.style.backgroundColor='Silver'");
              e.Row.Attributes.Add("onMouseOut", "this.style.background=this.previous_color;");
          }
      }

      private void BindGrid()
      {
          string email = SearchEmail.Value.Trim();
          bool isAdmin = SearchAdmin.Checked;
          DataTable dt = oUserBLL.searchUser(email, isAdmin);
          UserList.DataSource = dt;
          UserList.DataBind();         
      }

      protected void UserList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
      {
          UserList.PageIndex = e.NewPageIndex;
          this.BindGrid();
      }

      protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
      {
          int userId = int.Parse(UserList.SelectedRow.Cells[0].Text);
          string firstName = UserList.SelectedRow.Cells[1].Text;
          string lastName = UserList.SelectedRow.Cells[2].Text;
          string email = UserList.SelectedRow.Cells[3].Text;
          string phone = UserList.SelectedRow.Cells[4].Text;                
          string address = UserList.SelectedRow.Cells[5].Text;
          UserId.Value = userId.ToString();
          FirstName.Value = firstName;
          LastName.Value = lastName;
          Email.Value = email;
          Phone.Value = phone;
          Address.Value = address;
          enableEditUserFields();
      }
 
    protected void btnUpdateUser_ServerClick(object sender, EventArgs e)
    {
        int userId = int.Parse(UserId.Value);
        string firstName =  FirstName.Value;
        string lastName = LastName.Value;
        string email = Email.Value;
        string phone = Phone.Value;
        string address = Address.Value;
        User oUser = new User();
        oUser.UserId = userId;
        oUser.FirstName = firstName;
        oUser.LastName = lastName;
        oUser.Email = email;
        oUser.Phone = phone;
        oUser.Address = address;
        bool status =  oUserBLL.updateUser(oUser);
        string message = "";
        if (status)
        {
            this.BindGrid();
            message = "User details have been updated successfully.";           
        }
        else
        {
            message = "User details updation failed.";           
        }
        string script = "window.onload = function(){ alert('";
        script += message;
        script += "')};";
        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true); 
    }
    protected void btnDeleteUser_ServerClick(object sender, EventArgs e)
    {
        int userId = int.Parse(UserId.Value);       
        User oUser = new User();
        oUser.UserId = userId;      
        bool status = oUserBLL.deleteUser(oUser);
        string message = "";
        if (status)
        {
            this.BindGrid();
            message = "User details have been deleted successfully.";
        }
        else
        {
            message = "User details deletion failed.";
        }
        string script = "window.onload = function(){ alert('";
        script += message;
        script += "')};";
        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true); 
    }
    protected void btnDisableUser_ServerClick(object sender, EventArgs e)
    {
        string email = Email.Value;
        User oUser = new User();
        oUser.Email = email;
        bool status = oUserBLL.disableUser(oUser);
        string message = "";
        if (status)
        {
            this.BindGrid();
            message = "User details have been disabled successfully.";
        }
        else
        {
            message = "User details disabling failed.";
        }
        string script = "window.onload = function(){ alert('";
        script += message;
        script += "')};";
        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true); 
    }
    protected void btnSearchUser_ServerClick(object sender, EventArgs e)
    {
        this.BindGrid();
        enableEditUserFields();
    }

    private void enableEditUserFields()
    {
        FirstName.Disabled = false;
        LastName.Disabled = false;
        Email.Disabled = false;
        Phone.Disabled = false;
        Address.Disabled = false;
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