using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingLot.App_Domain
{
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