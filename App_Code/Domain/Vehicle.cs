using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Vehicle
/// </summary>
public class Vehicle
{

    private string id;
    private string brand;
    private bool vehicleType;


    public Vehicle()
    {


    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }
    public bool VehicleType
    {
        get { return vehicleType; }
        set { vehicleType = value; }
    }

}
