using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BookingBusiness
/// </summary>
    public class BookingBusiness
    {
        private Booking currentBooking;
        private User currentUser;
        private Vehicle userSelectedVehicle;
        private ParkingSpot selectedParkingSpot;

        public void BookSpot(ParkingSpot selectedSpot, DateTime entryTime, DateTime exitTime)
        {
            currentBooking.IdParkingSpot = selectedSpot;
            currentBooking.EntryTime = entryTime;
            currentBooking.ExitTime = exitTime;
            addUserDataToBook();
        }
        public void addUserDataToBook()
        {
            currentBooking.IdUser = currentUser;
            currentBooking.IdVehicle = userSelectedVehicle;
            currentBooking.Date = DateTime.Now;
        }

        public void verifyTime()
        {
            if (currentBooking.EntryTime.AddMinutes(15) <= currentBooking.Date)
            {
                //Throw error here invalid time selection (to short time span)
            }
        }
        public DataTable GetReportBooking()
        {
            BookingData bookingData = new BookingData();

            return bookingData.GetReportBooking();
        }

    public void InsertBooking(Booking bookingToAdd)
    {
        BookingData bookingData = new BookingData();
        bookingData.Insert(bookingToAdd);
    }
   }
