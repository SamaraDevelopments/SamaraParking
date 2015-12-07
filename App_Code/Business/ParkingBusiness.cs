using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PakingBusiness
/// </summary>
public class ParkingBusiness
{
    public ParkingBusiness()
    {

    }
    public int AddParking(ParkingLot parkingToAdd)
    {
        ParkingLotData pld = new ParkingLotData();
        int insertResult = pld.Insert(parkingToAdd);

        return insertResult;
    }
    public int VerifyParking(ParkingLot parkingToAdd)
    {
        ParkingLotData pld = new ParkingLotData();
        int insertResult = pld.VerifyName(parkingToAdd);

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
    public void AddParkingSpot(ParkingSpot parkingSpotToAdd)
    {
        ParkingSpotData psd = new ParkingSpotData();
        psd.Insert(parkingSpotToAdd);

    }
    public DataSet GetParkingForBooking()
    {
        ParkingLotData pld = new ParkingLotData();

        return pld.GetParkingForBooking();
    }
    public int DeleteParking(ParkingLot parkingToDelete)
    {
        ParkingLotData pld = new ParkingLotData();
        int insertResult = pld.Delete(parkingToDelete);

        return insertResult;
    }
    public ParkingLot GetDimensions(ParkingLot parkingToTable)
    {
        ParkingLotData pld = new ParkingLotData();
        parkingToTable = pld.GetParkingTable(parkingToTable);

        return parkingToTable;
    }
    public int GetSpotFromPosition(int selectedPosition, int parkingId)
    {

        ParkingSpotData psd = new ParkingSpotData();
        int spotId = psd.GetSpot(selectedPosition, parkingId);
        return spotId;
    }
    public string GetSpotType(int spotId)
    {
        ParkingSpotData psd = new ParkingSpotData();
        return psd.GetSpotType(spotId);
    }
}