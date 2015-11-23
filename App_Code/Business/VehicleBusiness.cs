using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VehicleBusiness
/// </summary>
public class VehicleBusiness
{
    

    public VehicleBusiness()
	{ }

    public List<Vehicle> GetUserListOfVehicles(User user)
    {
        List<Vehicle> userVehicles = new List<Vehicle>();
        VehicleData vd = new VehicleData();

        vd.GetIdVehiclesFromUserVehicles(user);

        user.ListOfVehicles = userVehicles;

        return userVehicles;
    }

    public string AddVehicle(Vehicle vehicleToAdd, User currentUser)
    {
        VehicleData vd = new VehicleData();
        int insertResult = vd.Insert(vehicleToAdd, currentUser);

        string failuretext = "";
        if (insertResult == -1)
        {
            failuretext = "La placa del vehiculo ya fue registrada.";
        }
        else
        {
            currentUser.ListOfVehicles.Add(vehicleToAdd);
            failuretext = "";
        }
        return failuretext;
    }

    
}