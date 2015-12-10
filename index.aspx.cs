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
            Session["ACTIVATION"] = "Inactivo";
        }
        else
        {
            LabelRegistryOfCommingUser.Text = "Activo";
            Session["ACTIVATION"] = "Activo";
        }
    }
    public void btnActiveRegistry_Click(object sender, EventArgs e)
    {
        Response.Redirect("useractivation.aspx");

    }

 
}