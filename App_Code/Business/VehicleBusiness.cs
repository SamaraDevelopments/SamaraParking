using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VehicleBusiness
/// </summary>
public class VehicleBusiness
{
    

    public VehicleBusiness()
	{
    }

    public Vehicle LoadVehicles(string idVehicle) {

        VehicleData vd = new VehicleData();
        Vehicle vehicle = new Vehicle();
        vehicle.Id = idVehicle;
        vehicle = vd.LoadVehicles(vehicle);

        return vehicle;
    }
    public bool ValidateLicensePlate(Vehicle vehicle)
    {
        bool isValid = true;
        string plate = vehicle.Id;
        if (plate.Length == 5)
        {
            for (int i = 0; i < 1; i++)
            {
                char currentLetter = plate[i];
                if (!char.IsLetter(plate, i))
                {
                    isValid = false;
                }
                else if ("aeiouAEIOU".Contains(currentLetter.ToString()))
                {
                    isValid = false;
                }

            }
            for (int i = 1; i < plate.Length; i++)
            {
                if (!char.IsNumber(plate, i))
                {
                    isValid = false;
                }
            }
        }
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
                char currentLetter = plate[i];
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

      public DataTable GetVehiclesFromUser(User user)
    {
        VehicleData vd = new VehicleData();

        return vd.GetVehiclesFromUser(user);
    }

    public string AddVehicle(Vehicle vehicleToAdd, User currentUser)
    {
        VehicleData vd = new VehicleData();
        int insertResult = vd.Insert(vehicleToAdd, currentUser);

        string failuretext = null;
        if (insertResult == 0)
        {
            failuretext = null;
        }
        else
        {
            failuretext = "La placa del vehiculo ya fue registrada.";
        }
        return failuretext;
    }
    public string DeleteVehicle(Vehicle vehicleToDelete, User currentUser)
    {
        VehicleData vd = new VehicleData();
        int deleteResult = vd.Delete(vehicleToDelete, currentUser);

        string failuretext = null;
        if (deleteResult == 0)
        {
            failuretext = null;
        }
        else
        {
            failuretext = "El vehiculo no se logro eliminar";
        }
        return failuretext;
    }
    public string EditVehicle(Vehicle vehicleToAdd)
    {
        VehicleData vd = new VehicleData();
        int EditResult = vd.Edit(vehicleToAdd);

        string failuretext = null;
        if (EditResult == 0)
        {
            failuretext = null;
        }
        else
        {
            failuretext = "El vehiculo no se logro editar";
        }
        return failuretext;
    }
    public DataSet GetVehiclesForBooking(User user)
    {
        VehicleData vd = new VehicleData();

        return vd.GetVehiclesForBoking(user);
    }
}