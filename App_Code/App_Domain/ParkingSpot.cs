using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ParkingSpot
/// </summary>
public class ParkingSpot
{
    private int id;
    private string spotType;

    public ParkingSpot()
    {


    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string SpotType
    {
        get { return this.spotType; }
        set { spotType = value; }
    }
}
}