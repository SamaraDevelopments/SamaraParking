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

        HttpCookie loginCookie = Request.Cookies["UserSettings"];
       
        if (loginCookie != null)
        {
            TextBoxEmailIncomingUser.Text = loginCookie["Email"];
            TextBoxPasswordIncomingUser.Text = loginCookie["Password"];
        }       

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        HttpCookie loginCookie = Request.Cookies["UserSettings"];

        if (loginCookie == null)
        {
            loginCookie = new HttpCookie("UserSettings");
        }

        LoginBusiness lb = new LoginBusiness();
        User loginUser = new User();
        loginUser.Email = TextBoxEmailIncomingUser.Text;
        loginUser.Password = TextBoxPasswordIncomingUser.Text;

        if (lb.ValidateUser(loginUser) == null)
        {

            Session["USER"] = lb.GetUser(loginUser);
            Response.Redirect("index.aspx");

            if (CheckBoxRememberIncomingUser.Checked)
            {               
                loginCookie["Email"] = loginUser.Email;
                loginCookie["Password"] = loginUser.Password;
                loginCookie.Expires = DateTime.Now.AddDays(30d);
                Response.Cookies.Add(loginCookie);
            }
            else
            {             
                loginCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(loginCookie);
            }

        }
        else
        {
            LabelError.Text = lb.ValidateUser(loginUser);

        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        TextBoxEmailIncomingUser.Text = string.Empty;
        TextBoxPasswordIncomingUser.Text = string.Empty;
    }




}