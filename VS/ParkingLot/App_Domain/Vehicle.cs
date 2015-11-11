using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingLot.App_Domain
{
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
            get { return this.brand; }
            set { brand = value; }
        }
        public string VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }      

    }
}