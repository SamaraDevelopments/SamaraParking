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
    private int dimensionX;
    private int dimensionY;
    private List<ParkingSpot> listOfSpots;
    private ParkingSpot[,] parkingSpotsMatrix;

    public ParkingLot()
    {
        ParkingSpotsMatrix = new ParkingSpot[10, 20];

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
    public int DimensionX
    {
        get { return dimensionX; }
        set { dimensionX = value; }
    }
    public int DimensionY
    {
        get { return dimensionY; }
        set { dimensionY = value; }
    }
    public List<ParkingSpot> ListOfSpots
    {
        get { return listOfSpots; }
        set { listOfSpots = value; }
    }

    public ParkingSpot[,] ParkingSpotsMatrix
    {
        get
        {
            return parkingSpotsMatrix;
        }

        set
        {
            parkingSpotsMatrix = value;
        }
    }
}