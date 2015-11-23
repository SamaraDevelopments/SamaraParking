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

        Session["USER"] = null;

        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                TextBox1.Text = Request.Cookies["UserName"].Value;
                TextBox2.Attributes["value"] = Request.Cookies["Password"].Value;
            }
        }

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

            if (CheckBox1.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

            }

            Response.Cookies["UserName"].Value = TextBox1.Text.Trim();
            Response.Cookies["Password"].Value = TextBox2.Text.Trim();
        }
        else
        {
            Label4.Text = lb.ValidateUser(loginUser);

        }

    }



    
}