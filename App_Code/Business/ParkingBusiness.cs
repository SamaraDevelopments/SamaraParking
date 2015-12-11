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
    public void AddParkingSpot(Table parkingTable, ParkingLot currentParking)
    {
        ParkingSpotData psd = new ParkingSpotData();
        psd.Insert(parkingTable, currentParking);

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
    public Table GetSpotData(ParkingLot pl, Table bookingTable)
    {
        ParkingSpotData psd = new ParkingSpotData();
        bookingTable = psd.GetSpot(pl, bookingTable);
        return bookingTable;
    }
    public ParkingSpot GetSpotForReserve(ParkingSpot ps, int position)
    {
        ParkingSpotData psd = new ParkingSpotData();
        ps = psd.GetSpotForReserve(ps, position);
        return ps;
    }
}