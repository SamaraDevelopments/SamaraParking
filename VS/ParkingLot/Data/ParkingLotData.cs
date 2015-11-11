using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ParkingLot.Data
{
    public class ParkingLotData : BaseData
    {
        public void Insert(App_Domain.ParkingLot newParkingLot)
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            string databaseCommand = "insert_parkinglot";

            SqlCommand sqlCommand;
            
            try
            {
                
                sqlCommand = new SqlCommand(databaseCommand, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = newParkingLot.Name;
                sqlCommand.Parameters.Add("@location", SqlDbType.NVarChar).Value = newParkingLot.Location;
                sqlCommand.Parameters.Add("@capacity", SqlDbType.Int).Value = newParkingLot.Capacity;

                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                ManageDatabaseConnection("Close");
            }
            catch (SqlException sqlException)
            {

                throw sqlException;
            }


        }
       
        public void Update(App_Domain.ParkingLot newParkingLot)
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            string databaseCommand = "update_parkinglot";

            SqlCommand sqlCommand;

            try
            {

                sqlCommand = new SqlCommand(databaseCommand, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = newParkingLot.Id;
                sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = newParkingLot.Name;
                sqlCommand.Parameters.Add("@location", SqlDbType.NVarChar).Value = newParkingLot.Location;
                sqlCommand.Parameters.Add("@capacity", SqlDbType.Int).Value = newParkingLot.Capacity;
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                ManageDatabaseConnection("Close");
            }
            catch (SqlException sqlException)
            {

                throw sqlException;
            }


        }

        public void Delete(App_Domain.ParkingLot newParkingLot)
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            string databaseCommand = "delete_parkinglot";

            SqlCommand sqlCommand;

            try
            {

                sqlCommand = new SqlCommand(databaseCommand, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = newParkingLot.Id;
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                ManageDatabaseConnection("Close");
            }
            catch (SqlException sqlException)
            {

                throw sqlException;
            }


        }

    }
}