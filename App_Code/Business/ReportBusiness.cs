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
        UserData userData = new UserData();
        results = userData.GetUsersAndProfesors();
        return results;
    }

//    public int[] getParkingUses()
//   {
//         int[] results;
//        BookingData bookingData = new BookingData();
//        results = bookingData.GetParkingUses();
//        return results;
//    }
}