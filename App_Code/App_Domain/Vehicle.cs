using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Vehicle
/// </summary>
public class Vehicle
{

    private int id;
    private string brand;
    private string vehicleType;


    public Vehicle()
    {


    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }
    public string VehicleType
    {
        get { return vehicleType; }
        set { vehicleType = value; }
    }

}
