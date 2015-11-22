using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


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
                failureText = "Correo incorrecto.";
                break;

            case -2:
                failureText = "Contraseña incorrecta.";
                break;

            case -3:
                failureText = "Tu cuenta no tiene marchamo.";
                break;

            default:
                failureText = null;
                break;
        }
        return failureText;
    }

    public User GetUser(User fromUser)
    {
        UserData ud = new UserData();

        return ud.GetUser(fromUser);
    }

}
