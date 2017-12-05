using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterTemplate : System.Web.UI.MasterPage
{
    private string userName = null;

    public string UserName
    {
        get
        {
            return liAcccount.InnerHtml;
        }
        set
        {
            liAcccount.InnerHtml = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetNoServerCaching();
        HttpContext.Current.Response.Cache.SetNoStore();
        if (Session["userid"] == null || !string.IsNullOrEmpty(Session["userid"] as string))
        {
            liLogin.Visible = true;
            liAcccount.Visible = false;
        }
        else
        {
            liAcccount.Visible = true;
            liLogin.Visible = false;
        }
    }
    protected void aLogout_ServerClick(object sender, EventArgs e)
    {
        string redirectPage = "/Trinkets/frmHome.aspx";
        Session.RemoveAll();
        Session.Abandon();
        liLogin.Visible = true;
        liAcccount.Visible = false;
        Response.Redirect(redirectPage);
    }
}
