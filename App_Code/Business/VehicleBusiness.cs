using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VehicleBusiness
/// </summary>
public class VehicleBusiness
{
    VehicleData vd = new VehicleData();


	public VehicleBusiness()
	{ }

    public string AddVehicle(Vehicle vehicleToAdd, User currentUser)
    {
        int insertResult = vd.Insert(vehicleToAdd, currentUser);

        string failuretext = "";
        if (insertResult == -1)
        {
            failuretext = "La placa del vehiculo ya fue registrada.";
        }
        else
        {
            failuretext = null;
        }
        return failuretext;
    }

}