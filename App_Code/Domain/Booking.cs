using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Booking
/// </summary>
public class Booking
{
    private int idBooking;
    private User idUser;
    private Vehicle idVehicle;
    private ParkingSpot idParkingSpot;
    private DateTime date;
    private DateTime entryTime;
    private DateTime exitTime;

    public int IdBooking
    {
        get
        {
            return idBooking;
        }

        set
        {
            idBooking = value;
        }
    }

    public User IdUser
    {
        get
        {
            return idUser;
        }

        set
        {
            idUser = value;
        }
    }

    public Vehicle IdVehicle
    {
        get
        {
            return idVehicle;
        }

        set
        {
            idVehicle = value;
        }
    }

    public ParkingSpot IdParkingSpot
    {
        get
        {
            return idParkingSpot;
        }

        set
        {
            idParkingSpot = value;
        }
    }

    public DateTime Date
    {
        get
        {
            return date;
        }

        set
        {
            date = value;
        }
    }

    public DateTime EntryTime
    {
        get
        {
            return entryTime;
        }

        set
        {
            entryTime = value;
        }
    }

    public DateTime ExitTime
    {
        get
        {
            return exitTime;
        }

        set
        {
            exitTime = value;
        }
    }
}