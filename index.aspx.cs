using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Form_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] == null)
        {
            Response.Redirect("login.aspx");
        }
        GetRegistryOfUser();
    }
    public void GetRegistryOfUser()
    {
        User user = (User)Session["USER"];
        if (user.Registry == false)
        {
            LabelRegistryOfCommingUser.Text = "Inactivo";
        }
        else
        {
            LabelRegistryOfCommingUser.Text = "Activo";
        }
    }
    public void btnActiveRegistry_Click(object sender, EventArgs e)
    {
        User currentUser = (User)Session["USER"];
        LoginBusiness lb = new LoginBusiness();
        currentUser.Registry = true;
        lb.ActiveRegistry(currentUser);
    }

    //public string GetCookie()
    //{
    //    HttpCookie loginCookie = Request.Cookies["UserSettings"];
    //    string msg = loginCookie["Email"].ToString();
    //    return msg;

    //}

}