using System;
using System.Web.Security;
using System.Web.UI;

namespace SamaraParking
{
    public partial class Login : Page
    {
        protected void ValidateUser(object sender, EventArgs e)
        {
            LoginBusiness lb = new LoginBusiness();
            User loginUser = new User();
            loginUser.Email = Login1.UserName;
            loginUser.Password = Login1.Password;

            if (lb.ValidateUser(loginUser) == null)
            {
            FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
            }
            else
            {
                Login1.FailureText = lb.ValidateUser(loginUser);
            }
             
        }
    }
}