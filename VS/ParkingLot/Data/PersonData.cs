using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ParkingLot.Data
{
    public class PersonData : BaseData
    {
        public void Insert(App_Domain.Person newPerson)
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            string databaseCommand = "insert_person";

            SqlCommand sqlCommand;

            try
            {

                sqlCommand = new SqlCommand(databaseCommand, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = newPerson.Name;
                sqlCommand.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = newPerson.Lastname;
                sqlCommand.Parameters.Add("@roletype", SqlDbType.Int).Value = newPerson.Roletype;
                sqlCommand.Parameters.Add("@registry", SqlDbType.Bit).Value = newPerson.Registration;
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                ManageDatabaseConnection("Close");
            }
            catch (SqlException sqlException)
            {

                throw sqlException;
            }


        }
        public void Update(App_Domain.Person newPerson)
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            string databaseCommand = "update_person";

            SqlCommand sqlCommand;

            try
            {

                sqlCommand = new SqlCommand(databaseCommand, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = newPerson.Id;
                sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = newPerson.Name;
                sqlCommand.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = newPerson.Lastname;
                sqlCommand.Parameters.Add("@roletype", SqlDbType.Int).Value = newPerson.Roletype;
                sqlCommand.Parameters.Add("@registry", SqlDbType.Bit).Value = newPerson.Registration;
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                ManageDatabaseConnection("Close");
            }
            catch (SqlException sqlException)
            {

                throw sqlException;
            }


        }

        public void Delete(App_Domain.Person newPerson)
        {
            //open database connection
            SqlConnection connection = ManageDatabaseConnection("Open");

            string databaseCommand = "delete_person";

            SqlCommand sqlCommand;

            try
            {

                sqlCommand = new SqlCommand(databaseCommand, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = newPerson.Id;              
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