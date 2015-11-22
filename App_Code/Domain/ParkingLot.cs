using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ParkingLot
/// </summary>
public class ParkingLot
{

    private int id;
    private string name;
    private string location;
    private int capacity;
    private List<ParkingSpot> listOfSpots;

    public ParkingLot()
    {


    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Location
    {
        get { return location; }
        set { location = value; }
    }
    public int Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }

    public List<ParkingSpot> ListOfSpots
    {
        get { return listOfSpots; }
        set { listOfSpots = value; }
    }
}