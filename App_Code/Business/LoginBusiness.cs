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

            default:
                failureText = null;
                break;
        }
        return failureText;
    }

    public User GetUser(User fromUser)
    {
        UserData ud = new UserData();
        VehicleBusiness vb = new VehicleBusiness();
        User userLoaded = ud.GetUser(fromUser);       
        userLoaded.ListOfVehicles = vb.LoadListOfVehicles(userLoaded);
        return userLoaded;
    }
    public void ActiveRegistry(User user)
    {
        UserData ud = new UserData();
        ud.ChangeRegistry(user);
    }
}
