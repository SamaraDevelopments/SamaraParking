using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

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
        ParkingLotData parkingLotData = new ParkingLotData();
        int insertResult = parkingLotData.Insert(parkingToAdd);

        return insertResult;
    }
    public int VerifyParking(ParkingLot parkingToAdd)
    {
        ParkingLotData parkingLotData = new ParkingLotData();
        int insertResult = parkingLotData.VerifyName(parkingToAdd);

        return insertResult;
    }
    public string UpdateParking(ParkingLot parkingToUpdate)
    {
        ParkingLotData parkingLotData = new ParkingLotData();
        int insertResult = parkingLotData.Update(parkingToUpdate);

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
    public void AddParkingSpot(Table parkingTable, ParkingLot currentParking)
    {
        ParkingSpotData parkingSpotData = new ParkingSpotData();
        parkingSpotData.Insert(parkingTable, currentParking);

    }
    public DataSet GetParkingForBooking()
    {
        ParkingLotData parkingLotData = new ParkingLotData();

        return parkingLotData.GetParkingForBooking();
    }
    public int DeleteParking(ParkingLot parkingToDelete)
    {
        ParkingLotData parkingLotData = new ParkingLotData();
        int insertResult = parkingLotData.Delete(parkingToDelete);

        return insertResult;
    }
    public ParkingLot GetDimensions(ParkingLot parkingToTable)
    {
        ParkingLotData parkingLotData = new ParkingLotData();
        parkingToTable = parkingLotData.GetParkingTable(parkingToTable);

        return parkingToTable;
    }
    public Table GetSpotData(ParkingLot parkingLot, Table bookingTable)
    {
        ParkingSpotData parkingSpotData = new ParkingSpotData();
        bookingTable = parkingSpotData.GetSpot(parkingLot, bookingTable);
        return bookingTable;
    }
    public ParkingSpot GetSpotForReserve(ParkingSpot parkingSpot, int position)
    {
        ParkingSpotData parkingSpotData = new ParkingSpotData();
        parkingSpot = parkingSpotData.GetSpotForReserve(parkingSpot, position);
        return parkingSpot;
    }
}