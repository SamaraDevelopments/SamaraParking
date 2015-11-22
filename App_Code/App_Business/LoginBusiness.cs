using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoginBusiness
/// </summary>
public class LoginBusiness
{
    UserData ud = new UserData();
    public LoginBusiness()
    { }

    public string ValidateUser(User loginUser)
    {
        int validationType = ud.ValidateUser(loginUser);

        string failureText = "";

        switch (validationType)
        {
            case -1:
                failureText = "Username is incorrect.";
                break;

            case -2:
                failureText = "Password is incorrect.";
                break;

            case -3:
                failureText = "Account has not been activated.";
                break;

            default:
                failureText = null;
                break;
        }
        return failureText;
    }


}
