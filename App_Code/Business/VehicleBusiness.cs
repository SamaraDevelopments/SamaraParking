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
    public bool ValidateLicensePlate(Vehicle vehicle)
    {
        bool isValid = true;
        string plate = vehicle.Id;
        if (plate.Length == 6)
        {
            for (int i = 0; i < plate.Length; i++)
            {
                if(!char.IsNumber(plate, i)){
                    isValid = false;
                }
            }
        }
        else if (plate.Length == 7)
        {
            char holder = plate[4];
            for (int i = 0; i < 3; i++)
            {
                char currentLetter = plate[i + 1];
                if (!char.IsLetter(plate, i))
                {
                    isValid = false;
                }
                else if ("aeiouAEIOU".Contains(currentLetter.ToString()))
                {
                    isValid = false;
                }
            }
            if (holder.Equals("-"))
            {
                for (int i = 4; i < plate.Length; i++)
                {
                    if (!char.IsNumber(plate, i))
                    {
                        isValid = false;
                    }
                }
            }
        }
        else
        {
            isValid = false;
        }
        return isValid;
    }

    public List<Vehicle> GetUserVehicles(User user)
    {

        List<Vehicle> userVehicles = user.ListOfVehicles;

        return userVehicles;
    }

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

        string failuretext = null;
        if (insertResult == 0)
        {
            currentUser.ListOfVehicles.Add(vehicleToAdd);
            failuretext = null;
        }
        else
        {
            failuretext = "La placa del vehiculo ya fue registrada.";
        }
        return failuretext;
    }

    
}