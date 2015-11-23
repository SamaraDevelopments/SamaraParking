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
        if (Session["USER"] = null)
        {
            Response.Redirect(Login.aspx);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
    }
}