﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingLot.App_Domain
{
    public class Person
    {

        private int id;
        private string name;
        private string lastname;
        private int roletype;
        private bool registration;
        private List<Vehicle> listOfCars;

        public Person()
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
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public int Roletype
        {
            get { return roletype; }
            set { roletype = value; }
        }

        public bool Registration
        {
            get { return registration; }
            set { registration = value; }
        }

        public List<Vehicle> ListOfCars
        {
            get { return listOfCars; }
            set { listOfCars = value; }
        }

    }
}