using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PakingBusiness
/// </summary>
public class PakingBusiness
{
    public PakingBusiness()
    {

    }
    public string AddParking(ParkingLot parkingToAdd) 
    { 
        ParkingLotData pld = new ParkingLotData();
        int insertResult = pld.Insert(parkingToAdd);

        string failuretext = null;
        if (insertResult != 1)
        {
            failuretext = "El parqueo ya fue creado";
        }
        else
        {
            failuretext = null;
        }
        return failuretext;
    }
    public string UpdateParking(ParkingLot parkingToUpdate)
    {
        ParkingLotData pld = new ParkingLotData();
        int insertResult = pld.Update(parkingToUpdate);

        string failuretext = null;
        if (insertResult != 0)
        {
            failuretext = "No se pudo actualizar";
        }
        else
        {
            failuretext = "Se actualizo de manera exitosa";
        }
        return failuretext;
    }
    public void AddParkingSpot(ParkingSpot parkingSpotToAdd, ParkingLot parkingLotToAdd) 
    {
        ParkingSpotData psd = new ParkingSpotData();
        psd.Insert(parkingSpotToAdd, parkingLotToAdd);
    }
       
}