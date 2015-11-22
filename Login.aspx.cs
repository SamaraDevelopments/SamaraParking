using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Form_login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
       

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
        LoginBusiness lb = new LoginBusiness();
        User loginUser = new User();
        loginUser.Email = TextBox1.Text;
        loginUser.Password = TextBox2.Text;

        if (lb.ValidateUser(loginUser) == null)
        {
            Session["USER"] = lb.GetUser(loginUser);
            Response.Redirect("index.aspx");
        }
        else
        {
            Label4.Text = lb.ValidateUser(loginUser);

        }
    }

    
}