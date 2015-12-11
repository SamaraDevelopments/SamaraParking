using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportBusiness
/// </summary>
public class ReportBusiness
{
    public ReportBusiness()
    {
      
    }
    public int[] getUsersAndProfesors()
    {
        int[] results;
        BookingData bd = new BookingData();
        results = bd.GetUsersAndProfesors();
        return results;
    }

    public int[] getParkingUses()
    {
         int[] results;
        BookingData bd = new BookingData();
        results = bd.GetParkingUses();
        return results;
    }
}