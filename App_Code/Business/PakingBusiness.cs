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
        if (insertResult != 0)
        {
            failuretext = null;
        }
        else
        {
            failuretext = "El parqueo ya fue creado";
        }
        return failuretext;
    }
    public void AddParkingSpot(ParkingSpot parkingSpotToAdd, ParkingLot parkingLotToAdd) 
    {
        ParkingSpotData psd = new ParkingSpotData();
        psd.Insert(parkingSpotToAdd,parkingLotToAdd);
    }
       
}