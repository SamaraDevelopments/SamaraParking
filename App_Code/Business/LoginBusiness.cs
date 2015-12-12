using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class LoginBusiness
{
    UserData userData = new UserData();

    public LoginBusiness()
    { }

    public string ValidateUser(User loginUser)
    {
        int validationType = userData.ValidateUser(loginUser);

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
        UserData userData = new UserData();
        VehicleBusiness vehicleBusiness = new VehicleBusiness();
        User userLoaded = userData.GetUser(fromUser);       
        userLoaded.ListOfVehicles = vehicleBusiness.LoadListOfVehicles(userLoaded);
        return userLoaded;
    }
    public void ActiveRegistry(User user)
    {
        UserData userData = new UserData();
        userData.ChangeRegistry(user);
    }
}
