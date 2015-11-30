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
    public int AddParking(ParkingLot parkingToAdd) 
    { 
        ParkingLotData pld = new ParkingLotData();
        int insertResult = pld.Insert(parkingToAdd);

        return insertResult;
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
    public int AddParkingSpot(ParkingSpot parkingSpotToAdd) 
    {
        ParkingSpotData psd = new ParkingSpotData();
        int insertResult = psd.Insert(parkingSpotToAdd);

        return insertResult;
    }
       
}